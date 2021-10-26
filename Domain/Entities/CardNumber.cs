using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CardNumber
    {
        private const int numberMinCharSize = 4;
        private const int numberMaxCharSize = 16;
        public string Value { get; }

        public CardNumber(long number):this(number.ToString())
        {
           
        }

        public CardNumber(string number)
        {
            if (string.IsNullOrEmpty(number)) throw new InvalidCardNumberException("invalid card number.");
            if (number.Length > numberMaxCharSize) throw new InvalidCardNumberException("invalid card number max size.");
            if (number.Length < numberMinCharSize) throw new InvalidCardNumberException("invalid card number min size.");

            this.Value = number;
        }

        public long toLong() => long.Parse(Value);
    }
}
