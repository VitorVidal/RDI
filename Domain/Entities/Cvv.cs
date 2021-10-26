using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cvv
    {
        private const int cvvMaxCharSize = 5;
        public string Value { get; }
        
        public Cvv(int cvv)
        {
            //Didn't any mention on the docs
            //if(cvv == 0) throw new ArgumentException("CVV can't be zero!");

            string sCvv = cvv.ToString();
            if (sCvv.Length > cvvMaxCharSize) throw new InvalidCvvException("Invalid Cvv size!");

            Value = sCvv;
        }

        public int toInt() => int.Parse(Value);
    }
}
