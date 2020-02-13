using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagement.objects
{
    public class RawKeyMap
    {
        private String keyTitle;
        private String value_;
        private int index;
        private String id;

        public string rKeyTitle { get => keyTitle; set => keyTitle = value; }
        public string rValue_ { get => value_; set => value_ = value; }
        public int rIndex { get => index; set => index = value; }
        public string rId { get => id; set => id = value; }

        public EncryptedKeyMap convertToEncryptedKeyMap()
        {
            EncryptedKeyMap encryptedKeyMap = new EncryptedKeyMap()
            {
                KeyTitle = rKeyTitle,
                PureValue = rValue_,
                Index = rIndex,
                Id = rId,
            };

            return encryptedKeyMap;
        }
    }
}
