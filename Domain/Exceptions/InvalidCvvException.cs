using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class InvalidCvvException : BaseException
    {
        public InvalidCvvException()
        {
        }

        public InvalidCvvException(string message)
            : base(message)
        {
        }

        public InvalidCvvException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
