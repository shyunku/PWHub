using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagement.objects
{
    class StopAllocationException : Exception
    {
        public StopAllocationException() : base("할당 도중 다른 프로세스에 의해 강제 중단되었습니다.")
        {
        }
        public StopAllocationException(String message) : base(message)
        {
        }
        public StopAllocationException(String message, Exception inner) : base(message, inner)
        {
        }
    }
}
