using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Controllers;
using Xunit;

namespace Card.Tests
{
    public class CardControllerTests
    {
        private ICardService cardService = null;

        public CardControllerTests()
        {
            cardService = new Moq<ICardService>() { };
        }
        [Fact]
        public async Task Save_success()
        {
            //Arrange
            var fakeOrderId = "12";
            var fakeOrder = GetFakeOrder();

            //...

            //Act
            var cardController = new CardController(cardService.Object);

            cardController.ControllerContext.HttpContext = _contextMock.Object;
            var actionResult = await cardController.Detail(fakeOrderId);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(actionResult);
            Assert.IsAssignableFrom<Order>(viewResult.ViewData.Model);
        }
    }
}
