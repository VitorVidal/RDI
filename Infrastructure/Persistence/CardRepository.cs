using Core.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class CardRepository:ICardRepository
    {
        private readonly CardContext context;
       
        public CardRepository(CardContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context)); 
        }

        public async Task<Card> Save(Card card)
        {
            await context.Cards.AddAsync(card);
            await context.SaveChangesAsync();
            return card;
        }

        public async Task<Card> Get(int id)
        {
            return await context.Cards.FindAsync(id);
        }
    }
}
