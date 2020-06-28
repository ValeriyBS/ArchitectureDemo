using System.Linq;
using Application.Interfaces.Persistence;
using Application.Orders.Commands.CreateOrder.Repository;
using AutoFixture;
using AutoMoqCore;
using Domain.Customers;
using Domain.Orders;
using Domain.ShoppingCartItems;
using Moq;
using Xunit;

namespace Application.Tests.Orders.Commands.CreateOrder.Repository
{
    public class OrderRepositoryFacadeTests
    {
        public OrderRepositoryFacadeTests()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _mocker = new AutoMoqer();
            _sut = _mocker.Create<OrderRepositoryFacade>();
        }

        private readonly Fixture _fixture;
        private readonly AutoMoqer _mocker;
        private readonly OrderRepositoryFacade _sut;

        [Fact]
        public void TestAddOrderShouldAddOrder()
        {
            //Arrange
            //Act
            _sut.AddOrder(new Order());

            //Assert
            _mocker.GetMock<IOrderRepository>()
                .Verify(c => c.Add(It.IsAny<Order>()), Times.Once);
        }

        [Fact]
        public void TestGetCartItemsShouldReturnListOfItemsWithCartId()
        {
            //Arrange
            var cartId = _fixture.Create<string>();
            var expectedShoppingCartItems = _fixture
                .Build<ShoppingCartItem>()
                .With(s => s.ShoppingCartId, cartId)
                .CreateMany()
                .ToList();

            var shoppingCartItems = _fixture
                .CreateMany<ShoppingCartItem>()
                .ToList();

            shoppingCartItems.AddRange(expectedShoppingCartItems);

            _mocker.GetMock<IShoppingCartItemRepository>()
                .Setup(s => s.GetAll())
                .Returns(shoppingCartItems.AsQueryable);

            //Act
            var result = _sut.GetCartItems(cartId);

            //Assert
            Assert.Equal(expectedShoppingCartItems, result);
        }

        [Fact]
        public void TestGetCustomerByEmailShouldReturnCorrectCustomer()
        {
            //Arrange
            var customerEmail = _fixture.Create<string>();
            var expectedCustomer = _fixture
                .Build<Customer>()
                .With(c => c.Email, customerEmail)
                .Create();

            var customers = _fixture.CreateMany<Customer>().ToList();

            customers.Add(expectedCustomer);

            _mocker.GetMock<ICustomerRepository>()
                .Setup(s => s.GetAll())
                .Returns(customers.AsQueryable);

            //Act
            var result = _sut.GetCustomerByEmail(customerEmail);

            //Assert
            Assert.Equal(expectedCustomer, result);
        }
    }
}