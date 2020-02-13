using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagement.objects
{
    public class RawAccountInfo
    {
        private String infoTitle;
        private List<RawKeyMap> keyBundle;
        private String initialAdditionTimestamp;
        private String recentModifiedTimestamp;
        private int viewCount;
        private String id_key;
        private int index;

        public int rViewCount { get => viewCount; set => viewCount = value; }
        public string rInfoTitle { get => infoTitle; set => infoTitle = value; }
        public string rID_key { get => id_key; set => id_key = value; }
        public string rInitialAdditionTimestamp { get => initialAdditionTimestamp; set => initialAdditionTimestamp = value; }
        public string rRecentModifiedTimestamp { get => recentModifiedTimestamp; set => recentModifiedTimestamp = value; }
        public List<RawKeyMap> rKeyBundle { get => keyBundle; set => keyBundle = value; }
        public int rIndex { get => index; set => index = value; }


        public AccountInfo convertToAccountInfo()
        {
            List<EncryptedKeyMap> keyMaps = new List<EncryptedKeyMap>();
            for(int i = 0; i < keyBundle.Count; i++)
            {
                keyMaps.Add(keyBundle[i].convertToEncryptedKeyMap());
            }

            AccountInfo accountInfo = new AccountInfo()
            {
                InfoTitle = rInfoTitle,
                ViewCount = rViewCount,
                ID_key = rID_key,
                InitialAdditionTimestamp = rInitialAdditionTimestamp,
                RecentModifiedTimestamp = rRecentModifiedTimestamp,
                KeyBundle = keyMaps,
                Index = rIndex
            };

            return accountInfo;
        }
    }
}
