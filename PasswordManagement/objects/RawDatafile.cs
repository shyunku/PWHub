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
        private List<AccountInfo> accountTable;
        private ArrayList accessFailureLog;

        public List<AccountInfo> rAccountTable { get => accountTable; set => accountTable = value; }
        public ArrayList rAccessFailureLog { get => accessFailureLog; set => accessFailureLog = value; }

        public EncryptedDatafile convertToEncryptedData(StringSecure stringSecure)
        {
            EncryptedDatafile newData = new EncryptedDatafile(stringSecure)
            {
                AccountTable = rAccountTable,
                AccessFailureLog = rAccessFailureLog
            };

            return newData;
        }
    }
}
