using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;
using Core.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    
    public class CardService:ICardService
    {
        private readonly ICardRepository cardRepository;     
        private readonly IDateTimeProvider dateTimeProvider;

        public CardService(ICardRepository cardRepository,IDateTimeProvider dateTimeProvider)
        {
           this.cardRepository = cardRepository;
           this.dateTimeProvider = dateTimeProvider;
        }
                
        public async Task<receiveCardResponse> Save(receiveCardRequest request)
        {
            CardNumber cardNumber = new CardNumber(request.CardNumber);
            Token token = new Token(cardNumber, new Cvv(request.CVV));
            var card = new Card(request.CustomerId, new CardNumber(request.CardNumber),dateTimeProvider.UtcNow());            
            card = await cardRepository.Save(card);  
            
            return new receiveCardResponse() { 
                Registration = card.Registration, 
                CardId = card.Id, 
                Token = token.Value 
            };

        }

        public async Task<bool> ValidateToken(validateTokenRequest request)
        {
            Card card = await cardRepository.Get(request.CardId);

            if (card == null) throw new CardNotFoundException($"Card {request.CardId} Not Found");
            if (card.CustomerId != request.CustomerId) return false;         
            if (card.isTokenExpired(dateTimeProvider)) return false;

            var calcToken = new Token(new CardNumber(card.Number), new Cvv(request.CVV));

            if (calcToken.Value != request.Token) return false;    
            
            return true;                   
        }
      
    }
}
