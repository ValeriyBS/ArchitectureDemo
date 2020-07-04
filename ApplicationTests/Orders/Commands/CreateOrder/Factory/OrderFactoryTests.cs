using System;
using System.Collections.Generic;
using System.Linq;
using Application.Orders.Commands.CreateOrder.Factory;
using AutoFixture;
using AutoMapper;
using Domain.Customers;
using Domain.OrderDetails;
using Domain.Orders;
using Domain.ShoppingCartItems;
using Xunit;

namespace Application.Tests.Orders.Commands.CreateOrder.Factory
{
    public class OrderFactoryTests
    {
        public OrderFactoryTests()
        {
            var fixture = new Fixture();

            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var config = new MapperConfiguration(c =>
            {
                c.AddProfile<OrderDetailProfile>();
                c.CreateMap<ShoppingCartItem, OrderDetail>();
            });

            var mapper = config.CreateMapper();

            _sut = new OrderFactory(mapper);

            _customer = fixture.Create<Customer>();
            _dateTime = new DateTime(2020, 06, 27);
            _shoppingCartItems = fixture.CreateMany<ShoppingCartItem>(CartItemCount).ToList();
        }

        private readonly Customer _customer;
        private readonly DateTime _dateTime;
        private readonly List<ShoppingCartItem> _shoppingCartItems;
        private readonly OrderFactory _sut;
        private const int CartItemCount = 2;

        [Fact]
        public void TestCreateShouldReturnOrder()
        {
            //Arrange
            var expectedOrderTotal = _shoppingCartItems.Sum(i => i.ShopItem.Price * i.Amount);

            //Act
            var result = _sut.Create(_dateTime, _customer, _shoppingCartItems);

            //Assert
            Assert.IsType<Order>(result);

            Assert.Equal(_dateTime, result.OrderPlaced);

            Assert.Equal(_customer, result.Customer);

            Assert.Equal(expectedOrderTotal, result.OrderTotal);

            Assert.Equal(CartItemCount,result.OrderDetails.Count);
        }

        [Fact]
        public void TestCreateShouldThrowArgumentNullExceptionWhenCustomerNull()
        {
            //Arrange
            //Act
            Assert.Throws<ArgumentNullException>(
                //Assert
            ()=> _sut.Create(_dateTime,null!,_shoppingCartItems));
        }

        [Fact]
        public void TestCreateShouldThrowArgumentNullExceptionWhenShoppingCartItemsNull()
        {
            //Arrange
            //Act
            Assert.Throws<ArgumentNullException>(
                //Assert
                () => _sut.Create(_dateTime, _customer, null!));
        }

        [Fact]
        public void TestCreateShouldThrowArgumentNullExceptionWhenShoppingCartItemsEmpty()
        {
            //Arrange
            const string expectedExceptionMessage = "Shop items list is empty";
            //Act
            var ex = Assert.Throws<ArgumentException>(
                //Assert
                () => _sut.Create(_dateTime, _customer, new List<ShoppingCartItem>()));

            Assert.Equal(expectedExceptionMessage,ex.Message);
        }
    }
}