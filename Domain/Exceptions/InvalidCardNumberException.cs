using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class InvalidCardNumberException : BaseException
    {
        public InvalidCardNumberException()
        {
        }

        public InvalidCardNumberException(string message)
            : base(message)
        {
        }

        public InvalidCardNumberException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
