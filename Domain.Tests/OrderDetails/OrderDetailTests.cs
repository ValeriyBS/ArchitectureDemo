using AutoFixture;
using Domain.OrderDetails;
using Domain.Orders;
using Domain.ShopItems;
using Tests.Core.AutoFixture;
using Xunit;

namespace Domain.Tests.OrderDetails
{
    public class OrderDetailTests
    {
        public OrderDetailTests()
        {
            _orderDetail = new OrderDetail();

            var fixture = new OmitRecursionFixture();

            _shopItem = fixture.Create<ShopItem>();
            _order = fixture.Create<Order>();
        }

        private readonly OrderDetail _orderDetail;
        private readonly ShopItem _shopItem;
        private readonly Order _order;
        private const int OrderId = 1;
        private const int ShopItemId = 2;
        private const int Amount = 3;
        private const int Id = 4;
        private const decimal Price = 4.5m;

        [Fact]
        public void TestSetGetAmount()
        {
            //Arrange
            //Act
            _orderDetail.Amount = Amount;

            //Assert
            Assert.Equal(Amount, _orderDetail.Amount);
        }

        [Fact]
        public void TestSetGetId()
        {
            //Arrange
            //Act
            _orderDetail.Id = Id;

            //Assert
            Assert.Equal(Id, _orderDetail.Id);
        }

        [Fact]
        public void TestSetGetOrder()
        {
            //Arrange
            //Act
            _orderDetail.Order = _order;

            //Assert
            Assert.Equal(_order, _orderDetail.Order);
        }

        [Fact]
        public void TestSetGetOrderId()
        {
            //Arrange
            //Act
            _orderDetail.OrderId = OrderId;

            //Assert
            Assert.Equal(OrderId, _orderDetail.OrderId);
        }

        [Fact]
        public void TestSetGetPrice()
        {
            //Arrange
            //Act
            _orderDetail.Price = Price;

            //Assert
            Assert.Equal(Price, _orderDetail.Price);
        }

        [Fact]
        public void TestSetGetShopItem()
        {
            //Arrange
            //Act
            _orderDetail.ShopItem = _shopItem;

            //Assert
            Assert.Equal(_shopItem, _orderDetail.ShopItem);
        }

        [Fact]
        public void TestSetGetShopItemId()
        {
            //Arrange
            //Act
            _orderDetail.ShopItemId = ShopItemId;

            //Assert
            Assert.Equal(ShopItemId, _orderDetail.ShopItemId);
        }
    }
}