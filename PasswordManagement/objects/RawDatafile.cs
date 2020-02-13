using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagement.objects
{
    public class RawDatafile
    {
        private List<RawAccountInfo> accountTable;
        private ArrayList accessFailureLog;

        public List<RawAccountInfo> rRawAccountTable { get => accountTable; set => accountTable = value; }
        public ArrayList rAccessFailureLog { get => accessFailureLog; set => accessFailureLog = value; }

        public EncryptedDatafile convertToEncryptedData(StringSecure stringSecure)
        {
            //비암호화 파일 복호화
            //현재 상태의 비밀번호는 그대로 유지
            List<AccountInfo> accounts = new List<AccountInfo>();
            for(int i = 0; i < accountTable.Count; i++)
            {
                accounts.Add(accountTable[i].convertToAccountInfo());
            }

            EncryptedDatafile newData = new EncryptedDatafile(stringSecure)
            {
                AccountTable = accounts,
                AccessFailureLog = rAccessFailureLog
            };

            return newData;
        }
    }
}
