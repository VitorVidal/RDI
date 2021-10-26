using System;
using Xunit;

namespace CardController
{
    public class UnitTest1
    {
        [Fact]
        public async Task Should_Generate_Token_Success()
        {
            //Arrange
            var fakeOrderId = "12";
            var fakeOrder = GetFakeOrder();

            //...

            //Act
            var controller = new CardController(
                _orderServiceMock.Object,
                _basketServiceMock.Object,
                _identityParserMock.Object);

            orderController.ControllerContext.HttpContext = _contextMock.Object;
            var actionResult = await orderController.Detail(fakeOrderId);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(actionResult);
            Assert.IsAssignableFrom<Order>(viewResult.ViewData.Model);
        }
    }
}
