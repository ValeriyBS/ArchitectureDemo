using System;
using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;
using Application.Orders.Commands.CreateOrder;
using Application.Orders.Commands.CreateOrder.Factory;
using Application.Orders.Commands.CreateOrder.Repository;
using AutoFixture;
using AutoMoqCore;
using Common.Dates;
using Domain.Customers;
using Domain.Orders;
using Domain.ShoppingCartItems;
using Moq;
using Xunit;

namespace Application.Tests.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandTests
    {
        public CreateOrderCommandTests()
        {
            var fixture = new Fixture();

            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            _customer = fixture.Create<Customer>();

            _dateTime = fixture.Create<DateTime>();

            _order = fixture.Create<Order>();

            _shoppingCartItems = fixture.CreateMany<ShoppingCartItem>().ToList();

            _createOrderModel = new CreateOrderModel(CustomerEmail, CartId);

            _mocker = new AutoMoqer();

            _mocker.GetMock<IOrderRepositoryFacade>()
                .Setup(o => o.GetCustomerByEmail(CustomerEmail))
                .Returns(_customer);

            _mocker.GetMock<IOrderRepositoryFacade>()
                .Setup(o => o.GetCartItems(CartId))
                .Returns(_shoppingCartItems);

            _mocker.GetMock<IDateTimeService>()
                .Setup(d => d.GetDateTime())
                .Returns(_dateTime);

            _mocker.GetMock<IOrderFactory>()
                .Setup(o => o.Create(_dateTime, _customer, _shoppingCartItems))
                .Returns(_order);

            _sut = _mocker.Create<CreateOrderCommand>();
        }

        private readonly CreateOrderModel _createOrderModel;
        private readonly AutoMoqer _mocker;
        private readonly Customer _customer;
        private readonly CreateOrderCommand _sut;
        private readonly List<ShoppingCartItem> _shoppingCartItems;
        private readonly DateTime _dateTime;
        private readonly Order _order;
        private const string CustomerEmail = "customerEmail";
        private const string CartId = "cartId";

        [Fact]
        public void TestsExecuteShouldAddOrder()
        {
            //Arrange
            //Act
            _sut.Execute(_createOrderModel);
            //Assert
            _mocker.GetMock<IOrderRepositoryFacade>()
                .Verify(o => o.AddOrder(_order), Times.Once);
        }

        [Fact]
        public void TestsExecuteShouldCreateOrder()
        {
            //Arrange
            //Act
            _sut.Execute(_createOrderModel);
            //Assert
            _mocker.GetMock<IOrderFactory>()
                .Verify(o => o.Create(_dateTime, _customer, _shoppingCartItems), Times.Once);
        }

        [Fact]
        public void TestsExecuteShouldExecuteSave()
        {
            //Arrange
            //Act
            _sut.Execute(_createOrderModel);
            //Assert
            _mocker.GetMock<IUnitOfWork>()
                .Verify(o => o.Save(), Times.Once);
        }

        [Fact]
        public void TestsExecuteShouldGetCustomer()
        {
            //Arrange
            //Act
            _sut.Execute(_createOrderModel);
            //Assert
            _mocker.GetMock<IOrderRepositoryFacade>()
                .Verify(o => o.GetCustomerByEmail(CustomerEmail), Times.Once);
        }

        [Fact]
        public void TestsExecuteShouldGetDateTime()
        {
            //Arrange
            //Act
            _sut.Execute(_createOrderModel);
            //Assert
            _mocker.GetMock<IDateTimeService>()
                .Verify(o => o.GetDateTime(), Times.Once);
        }

        [Fact]
        public void TestsExecuteShouldGetShoppingCartItems()
        {
            //Arrange
            //Act
            _sut.Execute(_createOrderModel);
            //Assert
            _mocker.GetMock<IOrderRepositoryFacade>()
                .Verify(o => o.GetCartItems(CartId), Times.Once);
        }
    }
}