using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagement.objects
{
    class RawKeyMap
    {
        private String keyTitle;
        private String value_;
        private int index;
        private String id;

        public string rKeyTitle { get => keyTitle; set => keyTitle = value; }
        public string rValue_ { get => value_; set => value_ = value; }
        public int rIndex { get => index; set => index = value; }
        public string rId { get => id; set => id = value; }

    }
}
