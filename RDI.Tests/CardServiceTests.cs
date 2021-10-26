using Application.DTOs;
using Application.Exceptions;
using Application.Services;
using Core.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RDI.Tests
{
    public class TestDataGenerator : IEnumerable<object[]>
    {      

        public static IEnumerable<object[]> GetvalidateTokenRequestFromDataGenerator()
        {
            yield return new validateTokenRequest[]
            {
               new validateTokenRequest(){CustomerId = 1,CardId = 1201,Token = 6789,CVV=4}, //Card not found fail
               new validateTokenRequest(){CustomerId = 2,CardId = 121,Token = 6789,CVV=4}, // customer id fail             
               new validateTokenRequest(){CustomerId = 1,CardId = 121,Token = 6789,CVV=123456}, // cvv fail
               new validateTokenRequest(){CustomerId = 1,CardId = 121,Token = 1234,CVV=4}, // wrong token
               new validateTokenRequest(){CustomerId = 1,CardId = 121,Token = 6789,CVV=4} // it's ok
            };           
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }


    public class CardServiceTests
    {
        private Mock<IDateTimeProvider> dateTimeProviderMock;
        private Mock<ICardRepository> cardRepositoryMock;

        public CardServiceTests()
        {
            dateTimeProviderMock = new Mock<IDateTimeProvider>();
            cardRepositoryMock = new Mock<ICardRepository>();
        }


        public async Task<bool> ValidateToken(validateTokenRequest request)
        {
            CardService service = new CardService(cardRepositoryMock.Object, dateTimeProviderMock.Object);
            return await service.ValidateToken(request);
        }

        [Theory]
        [MemberData(nameof(TestDataGenerator.GetvalidateTokenRequestFromDataGenerator), MemberType = typeof(TestDataGenerator))]
        public async void ValidateToken_Should_Fail(validateTokenRequest notFoundFail, validateTokenRequest customerIdFail, validateTokenRequest cvvFail, validateTokenRequest wrongTokenFail, validateTokenRequest ok)
        {
            dateTimeProviderMock.Setup(x => x.UtcNow()).Returns(DateTime.UtcNow);
            Card card = new Card(121, 1, "123456789", DateTime.UtcNow);
            cardRepositoryMock.Setup(x => x.Get(121)).Returns(Task.FromResult(card));

            _ = Assert.ThrowsAsync<CardNotFoundException>(async () => await ValidateToken(notFoundFail));
            Assert.False(await ValidateToken(customerIdFail));
            _ = Assert.ThrowsAsync<InvalidCvvException>(async () => await ValidateToken(cvvFail));
            Assert.False(await ValidateToken(wrongTokenFail));

            //For token expired test!
            dateTimeProviderMock.Setup(x => x.UtcNow()).Returns(DateTime.UtcNow.AddMinutes(Card.tokenLifeTimeInMinutes));
            Assert.False(await ValidateToken(ok));
        }

        [Fact]
        public async Task ValidateToken_Should_Return_SuccessAsync()
        {
            dateTimeProviderMock.Setup(x => x.UtcNow()).Returns(DateTime.UtcNow);
            Card card = new Card(121, 1, "123456789", DateTime.UtcNow);
            cardRepositoryMock.Setup(x => x.Get(121)).Returns(Task.FromResult(card));

            var request = new validateTokenRequest() { CustomerId = 1, CardId = 121, Token = 6789, CVV = 4 };

            Assert.True(await ValidateToken(request));

        }
    }
}
