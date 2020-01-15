using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagement
{
    public class EncryptedKeyMap
    {
        //값 이름
        private String keyTitle;
        //값(패스워드 등)
        private String value;

        private int index;
        private String id;

        public string KeyTitle { get => keyTitle; set => keyTitle = value; }
        public string Value { get => value; set => this.value = value; }
        public int Index { get => index; set => index = value; }
        public string Id { get => id; set => id = value; }

        public EncryptedKeyMap(String key, String value, int index)
        {
            this.KeyTitle = key;
            this.Value = value;
            this.Index = index;
            this.Id = Utils.getRandomKey();
        }
    }
}
