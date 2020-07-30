using System.Linq;
using Application.Orders.Commands.CreateOrdersListViewModel.Factory;
using AutoFixture;
using Domain.Orders;
using Tests.Core.AutoFixture;
using Xunit;

namespace Application.Tests.Orders.Commands.CreateOrdersListViewModel.Factory
{
    public class OrdersListViewModelFactoryTests
    {
        [Fact]
        public void TestCreateShouldReturnOrdersListViewModel()
        {
            //Arrange
            const int testPageSize = 2;
            const int testPageIndex = 1;
            var fixture = new OmitRecursionFixture();
            var orders = fixture.CreateMany<Order>().ToList();
            var sut = new OrdersListViewModelFactory();

            //Act
            var result = sut.Create(orders, testPageSize, testPageIndex);

            //Assert
            Assert.Equal(testPageSize, result.PageSize);
            Assert.Equal(testPageIndex, result.PageIndex);
            Assert.Equal(orders.Take(2), result.Orders);
        }
    }
}