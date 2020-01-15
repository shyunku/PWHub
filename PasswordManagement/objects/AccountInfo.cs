using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Newtonsoft.Json;

namespace PasswordManagement
{
    public class AccountInfo
    {
        private String infoTitle;
        private List<EncryptedKeyMap> keyBundle;
        private String initialAdditionTimestamp;
        private String recentModifiedTimestamp;
        private int viewCount;
        private String id_key;
        private int index;

        public int ViewCount { get => viewCount; set => viewCount = value; }
        public string InfoTitle { get => infoTitle; set => infoTitle = value; }
        public string ID_key { get => id_key; set => id_key = value; }
        public string InitialAdditionTimestamp { get => initialAdditionTimestamp; set => initialAdditionTimestamp = value; }
        public string RecentModifiedTimestamp { get => recentModifiedTimestamp; set => recentModifiedTimestamp = value; }
        public List<EncryptedKeyMap> KeyBundle { get => keyBundle; set => keyBundle = value; }
        public int Index { get => index; set => index = value; }

        public AccountInfo(String infoTitle, int index)
        {
            this.KeyBundle = new List<EncryptedKeyMap>();
            this.InfoTitle = infoTitle;
            this.InitialAdditionTimestamp = Utils.getCurrentFormattedTimeString();
            this.RecentModifiedTimestamp = Utils.getCurrentFormattedTimeString();
            this.ID_key = Utils.getRandomKey();
            this.ViewCount = 0;
            this.Index = index;
        }

        //Add, Delete, Move 시 호출
        private void revalidateIndex()
        {
            for (int i = 0; i < keyBundle.Count; i++)
            {
                keyBundle[i].Index = i + 1;
            }
        }

        public void addKeyPair(String key, String value)
        {
            keyBundle.Add(new EncryptedKeyMap(key, value, keyBundle.Count+1));
            revalidateIndex();
        }

        public void deleteKeyPair(String id)
        {
            int curIndex = getIndexOfKeyData(id);
            keyBundle.RemoveAt(curIndex);
            revalidateIndex();
            return;
        }

        //계정 키값 변경
        public void modifyKeyPair(String keyPairId, String key, String value)
        {
            int curIndex = getIndexOfKeyData(keyPairId);
            keyBundle[curIndex].KeyTitle = key;
            keyBundle[curIndex].Value = value;
            modified();
        }

        private int getIndexOfKeyData(String id)
        {
            for (int i = 0; i < keyBundle.Count; i++)
            {
                EncryptedKeyMap cur = keyBundle[i];
                if (cur.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        public EncryptedKeyMap getEncryptedKeyMapById(String id)
        {
            int curIndex = getIndexOfKeyData(id);
            return keyBundle[curIndex];
        }


        public void viewed()
        {
            this.viewCount++;
        }

        public void modified()
        {
            this.RecentModifiedTimestamp = Utils.getCurrentFormattedTimeString();
        }
    }
}
