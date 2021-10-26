using Core.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using Moq;
using System;
using Xunit;

namespace RDI.Tests
{
    public class DomainTests
    {
        private Mock<IDateTimeProvider> dateTimeProviderMock;

        public DomainTests()
        {
            dateTimeProviderMock = new Mock<IDateTimeProvider>();
        }
        [Theory]
        [InlineData(12345678912345678)]
        [InlineData(1)]
        public void CreateCard_With_Invalid_CardNumber_Should_Fail(long number)
        {
            dateTimeProviderMock.Setup(x => x.UtcNow()).Returns(DateTime.UtcNow);
           Assert.Throws<InvalidCardNumberException>(() => new Card(1, new CardNumber(number), dateTimeProviderMock.Object.UtcNow()));
        }
     

        [Theory]
        [InlineData(1234, 1, 4123)]
        [InlineData(1234, 2, 3412)]
        [InlineData(1234, 3, 2341)]
        [InlineData(1234, 4, 1234)]
        [InlineData(1234, 5, 4123)]
        [InlineData(1234, 6, 3412)]
        [InlineData(1234, 7, 2341)]
        [InlineData(1234, 8, 1234)]
        [InlineData(1234, 9, 4123)]

        public void CreateToken_Should_Return_Expected_Value(long number, int cvv, long expected)
        {
            Token token = new Token(new CardNumber(number),new Cvv(cvv));
            long tokenValue = token.Value;
            Assert.Equal(expected, tokenValue);         
        }

        [Fact]
        public void CreateToken_With_Invalid_Cvv_ThrowsArgumentException()
        {
            Assert.Throws<InvalidCvvException>(() => new Token(new CardNumber(1234), new Cvv(123456)));
        }

    }
}
