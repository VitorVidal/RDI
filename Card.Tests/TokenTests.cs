using Xunit;

namespace Card.Tests
{
    public class TokenTests
    {
        [Theory]
        [InlineData(1234,1,4123)]
        [InlineData(1234,2, 3412)]
        [InlineData(1234,3, 2341)]
        [InlineData(1234,4, 1234)]
        [InlineData(1234,5, 4123)]
        [InlineData(1234,6, 3412)]
        [InlineData(1234,7, 2341)]
        [InlineData(1234,8, 1234)]
        [InlineData(1234,9, 4123)]

        public void CreateToken_Should_Return_Expected_Value(long number,int cvv,long expected)
        {
            Domain.Entities.Card card = new Domain.Entities.Card(1, number);
            long token = card.CreateToken(cvv);
            Assert.Equal(expected, token);
        }

        [Theory]
        [InlineData(1234, 1, 4123)]
        public void isTokenStillValid_Should_Return_Success()
        {
          


            Assert.Equal(expected, card.CreateToken(cvv));
        }
    }
}
