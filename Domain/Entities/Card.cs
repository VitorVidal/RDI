using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Card
    {       
        public static readonly short tokenLifeTimeInMinutes = 30;
       
        public int Id { get; }
        public int CustomerId { get; }
        public string Number { get;}
        public DateTime Registration { get; }
    
        public Card(int customerId, CardNumber cardNumber, DateTime registration)
        {
            this.Number = cardNumber.Value;
            this.CustomerId = customerId;
            this.Registration = registration;
        }

        public Card(int id, int customerId,string number, DateTime registration)
        {
            this.Id = id;
            this.CustomerId = customerId;
            this.Number = number;         
            this.Registration = registration;
        }  

        public bool isTokenExpired(IDateTimeProvider dateTimeProvider)
        {
            if (dateTimeProvider.UtcNow() > Registration.AddMinutes(tokenLifeTimeInMinutes)) return true;
            return false;
        }
    }
}
