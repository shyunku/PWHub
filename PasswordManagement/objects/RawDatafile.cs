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
        private String rootPassword;
        private String rootPasswordHint;
        private List<AccountInfo> accountTable;
        private ArrayList accessFailureLog;

        public string rRootPassword { get => rootPassword; set => rootPassword = value; }
        public string rRootPasswordHint { get => rootPasswordHint; set => rootPasswordHint = value; }
        public List<AccountInfo> rAccountTable { get => accountTable; set => accountTable = value; }
        public ArrayList rAccessFailureLog { get => accessFailureLog; set => accessFailureLog = value; }

        public EncryptedDatafile convertToEncryptedData(StringSecure stringSecure)
        {
            EncryptedDatafile newData = new EncryptedDatafile(stringSecure)
            {
                RootPassword = StringSecure.decodeBase64(rRootPassword),
                RootPasswordHint = rRootPasswordHint,
                AccountTable = rAccountTable,
                AccessFailureLog = rAccessFailureLog
            };

            return newData;
        }
    }
}
