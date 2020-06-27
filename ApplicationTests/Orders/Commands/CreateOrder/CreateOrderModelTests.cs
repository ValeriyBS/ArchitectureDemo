using System;
using Application.Orders.Commands.CreateOrder;
using AutoFixture;
using Xunit;

namespace Application.Tests.Orders.Commands.CreateOrder
{
    public class CreateOrderModelTests
    {
        public CreateOrderModelTests()
        {
            var fixture = new Fixture();
            _customerEmail = fixture.Create<string>();
            _shoppingCartId = fixture.Create<string>();
            _createOrderModel = new CreateOrderModel(_customerEmail, _shoppingCartId);
        }

        private readonly CreateOrderModel _createOrderModel;
        private readonly string _customerEmail;
        private readonly string _shoppingCartId;

        [Fact]
        public void TestCreateOrderModelShouldThrowArgumentNullExceptionWhenCartIdNull()
        {
            //Arrange
            //Act
            Assert.Throws<ArgumentNullException>(
                //Assert
                () => new CreateOrderModel("testCustomerEmail", null!));
        }

        [Fact]
        public void TestCreateOrderModelShouldThrowArgumentNullExceptionWhenCustomerEmailNull()
        {
            //Arrange
            //Act
            Assert.Throws<ArgumentNullException>(
                //Assert
                () => new CreateOrderModel(null!, "testCartId"));
        }

        [Fact]
        public void TestGetCustomerEmail()
        {
            //Arrange
            //Act
            //Assert
            Assert.Equal(_customerEmail, _createOrderModel.CustomerEmail);
        }

        [Fact]
        public void TestGetShoppingCatId()
        {
            //Arrange
            //Act
            //Assert
            Assert.Equal(_shoppingCartId, _createOrderModel.ShoppingCartId);
        }
    }
}