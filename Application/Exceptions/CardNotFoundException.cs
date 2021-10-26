using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class CardNotFoundException : BaseException
    {
        public CardNotFoundException()
        {
        }

        public CardNotFoundException(string message)
            : base(message)
        {
        }

        public CardNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
