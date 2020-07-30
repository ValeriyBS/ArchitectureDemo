using System.Globalization;
using Application.Orders.ExtensionMethods;
using AutoFixture;
using Domain.Orders;
using Tests.Core.AutoFixture;
using Xunit;

namespace Application.Tests.Orders.ExtensionMethods
{
    public class OrderExtensionsTests
    {
        [Fact]
        public void TestToHtmlShouldReturnHtmlStringWithOrderValues()
        {
            //Arrange
            var fixture = new OmitRecursionFixture();
            var sut = fixture.Create<Order>();

            //Act
            var result = sut.ToHtmlMessage();

            //Assert
            Assert.NotNull(result);
            Assert.StartsWith("<html>",result);
            Assert.Contains(sut.Id.ToString(), result);
            Assert.Contains(sut.OrderPlaced.ToString(CultureInfo.CurrentCulture), result);
            foreach (var orderDetail in sut.OrderDetails)
            {
                Assert.Contains(orderDetail.ShopItem.Name, result);
                Assert.Contains(orderDetail.Amount.ToString(), result);
                Assert.Contains((orderDetail.Price * orderDetail.Amount).ToString("C"), result);
            }

            Assert.Contains(sut.OrderTotal.ToString("C"), result);

            Assert.EndsWith("</html>", result);

        }

    }
}
