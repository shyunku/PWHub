using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows;

namespace PasswordManagement
{
    public class EncryptedDatafile
    {
        private const String ENCRYPT_TITLE = "PasswordManagement DataFile Encryption";
        public const String DEFAULT_ROOT_PW = "root";
        //Default: 최근 15분 내에 10번 초과의 시도가 있었을 시 시도 불가능 
        private const long TRY_LOGIN_TIME_RANGE = 15;
        private const int MAX_LOGIN_TRY_UNIT = 10;

        private String token;
        private String rootPassword;
        private String rootPasswordHint;
        private List<AccountInfo> accountTable;
        private ArrayList accessFailureLog;

        public string Token { get => token; set => token = value; }
        public string RootPassword { get => rootPassword; set => rootPassword = value; }
        public List<AccountInfo> AccountTable { get => accountTable; set => accountTable = value; }
        public ArrayList AccessFailureLog { get => accessFailureLog; set => accessFailureLog = value; }
        public string RootPasswordHint { get => rootPasswordHint; set => rootPasswordHint = value; }

        //새로운 데이터 파일 생성
        public EncryptedDatafile()
        {
            accessFailureLog = new ArrayList();
            accountTable = new List<AccountInfo>();
            token = getNewEncryptedToken();
            rootPasswordHint = "";
            registerNewPassword(DEFAULT_ROOT_PW);
        }

        public void registerNewPassword(String newPW)
        {
            rootPassword = StringSecure.encryptPassword(newPW);
        }

        public void registerNewPasswordHint(String newHint)
        {
            rootPasswordHint = newHint;
        }

        public String getNextAvailableLoginText()
        {
            long currentTime = Utils.getCurrentTimeMillis();
            long gapTime = ((long)accessFailureLog[0] + TRY_LOGIN_TIME_RANGE * 60 * 1000 - currentTime)/1000;
            long rMin = gapTime / 60;
            long rSec = gapTime % 60;

            return rMin + "분 " + rSec + "초";
        }

        public int canTryLogin()
        {
            int tryFailure = 0;
            long currentTime = Utils.getCurrentTimeMillis();
            ArrayList deletable = new ArrayList();
            
            foreach (long time in this.accessFailureLog)
            {
                long gapTime = currentTime - time;
                if (gapTime < TRY_LOGIN_TIME_RANGE * 60 * 1000)
                {
                    tryFailure++;
                }
                else
                {
                    deletable.Add(time);
                }
            }

            foreach(long time in deletable)
            {
                this.accessFailureLog.Remove(time);
            }

            if (tryFailure > MAX_LOGIN_TRY_UNIT) return -1;
            return MAX_LOGIN_TRY_UNIT - tryFailure;
        }

        public String getDecryptedRootPassword()
        {
            return StringSecure.decryptPassword(this.RootPassword);
        }

        public void viewedInfo(String id_key)
        {
            for(int i = 0; i < accountTable.Count; i++)
            {
                if (accountTable[i].ID_key.Equals(id_key))
                {
                    accountTable[i].viewed();
                }
            }
        }

        private void accessFailure()
        {
            AccessFailureLog.Add(Utils.getCurrentTimeMillis());
        }

        public bool isCorrectPassword(String inputPW)
        {
            if(getDecryptedRootPassword() == inputPW)
            {
                return true;
            }
            accessFailure();
            return false;
        }

        //Add, Delete, Move 시 호출
        private void revalidateIndex()
        {
            for (int i = 0; i < accountTable.Count; i++)
            {
                accountTable[i].Index = i + 1;
            }
        }

        //계정 정보 타이틀 변경
        public void modifyAccountTitle(String id, String title)
        {
            for (int i = 0; i < accountTable.Count; i++)
            {
                if (accountTable[i].ID_key.Equals(id))
                {
                    accountTable[i].InfoTitle = title;
                    accountTable[i].modified();
                    return;
                }
            }
        }

        //계정 키값 변경
        public void modifyKeyPair(String accountId, String keyPairId, String key, String value)
        {
            int index = getIndexOfAccount(accountId);
            AccountTable[index].modifyKeyPair(keyPairId, key, value);
        }

        //계정 정보 추가
        public void addAccountInfo(String title)
        {
            AccountTable.Insert(0, new AccountInfo(title, 1));
            revalidateIndex();
        }

        //계정 정보 삭제
        public void deleteAccountInfo(String id_key)
        {
            int curIndex = getIndexOfAccount(id_key);
            accountTable.RemoveAt(curIndex);
            revalidateIndex();
            return;
        }

        //계정 정보 위로 이동
        public void moveUp(String id_key)
        {
            int curIndex = getIndexOfAccount(id_key);
            int objIndex = curIndex - 1;
            if(objIndex < 0)
            {
                MessageBox.Show("최상위 항목은 위로 이동할 수 없습니다!", "인덱스 오류");
                return;
            }
            swapItem(curIndex, objIndex);
            revalidateIndex();
        }

        //계정 정보 위로 이동
        public void moveDown(String id_key)
        {
            int curIndex = getIndexOfAccount(id_key);
            int objIndex = curIndex + 1;
            if (objIndex > accountTable.Count - 1)
            {
                MessageBox.Show("최하위 항목은 아래로 이동할 수 없습니다!", "인덱스 오류");
                return;
            }
            swapItem(curIndex, objIndex);
            revalidateIndex();
        }

        public bool isSlideUpable(String id_key)
        {
            return getIndexOfAccount(id_key) != 0;
        }

        public bool isSlideDownable(String id_key)
        {
            return getIndexOfAccount(id_key) != accountTable.Count-1;
        }


        public AccountInfo getAccountInfo(String id_key)
        {
            foreach(AccountInfo info in AccountTable)
            {
                if (info.ID_key.Equals(id_key))
                {
                    return info;
                }
            }
            return null;
        }

        public void setAccountInfo(AccountInfo accountInfo)
        {
            for(int i=0;i<accountTable.Count;i++)
            {
                AccountInfo cur = accountTable[i];
                if (cur.ID_key.Equals(accountInfo.ID_key))
                {
                    accountTable[i] = accountInfo;
                    return;
                }
            }
        }

        private int getIndexOfAccount(String id_key)
        {
            for (int i = 0; i < accountTable.Count; i++)
            {
                AccountInfo cur = accountTable[i];
                if (cur.ID_key.Equals(id_key))
                {
                    return i;
                }
            }

            return -1;
        }

        private void swapItem(int i1, int i2)
        {
            AccountInfo tmp = accountTable[i1];
            accountTable[i1] = accountTable[i2];
            accountTable[i2] = tmp;
        }

        private String getNewEncryptedToken()
        {
            Guid guid = Guid.NewGuid();
            String GuidString = Convert.ToBase64String(guid.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            return GuidString;
        }
    }
}
