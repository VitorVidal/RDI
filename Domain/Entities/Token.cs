using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Token
    {
        public long Value { get; }
        public Token(CardNumber cardNumber,Cvv cvv)
        {
            Value = CreateToken(cardNumber,cvv);
        }

        //O(n*m)
        private long CreateToken(CardNumber cardNumber, Cvv cvv)
        {
            int shift = cvv.toInt() % 4;

            char[] last4 = cardNumber.Value.Substring(Math.Max(0, cardNumber.Value.Length - 4)).ToCharArray();

            for (int i = 0; i < shift; i++)
            {
                char lastElement = last4[3];
                for (int j = 3; j > 0; j--)
                {
                    last4[j] = last4[j - 1];
                }
                last4[0] = lastElement;
            }

            return long.Parse(last4);
        }
    }
}
