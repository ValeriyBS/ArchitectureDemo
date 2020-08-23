using System;
using System.Collections.Generic;
using System.Text;
using Application.Orders.Commands.CreateOrdersListViewModel.Factory;
using AutoFixture;
using Domain.Orders;
using Tests.Core.AutoFixture;
using Xunit;

namespace Application.Tests.Orders.Commands.CreateOrdersListViewModel.Factory
{
    public class OrdersListViewModelTests
    {
        private readonly IEnumerable<Order> _orders;
        private readonly OrdersListViewModel _ordersListViewModel;
        private const int PageSize = 1;
        private const int PageIndex = 2;
        private const int NumberOfPages = 3;
        private const int TotalNumberOfOrders = 4;
        private const int OrdersPageRatio = 5;
        private const bool HasPrevPage = true;
        private const bool HasNextPage = true;

        public OrdersListViewModelTests()
        {
            var fixture = new OmitRecursionFixture();
            _orders = fixture.CreateMany<Order>();
            _ordersListViewModel = new OrdersListViewModel();
        }

        [Fact]
        public void TestSetGetOrders()
        {
            //Arrange
            //Act
            _ordersListViewModel.Orders = _orders;

            //Assert
            Assert.Equal(_orders,_ordersListViewModel.Orders);
        }

        [Fact]
        public void TestSetGetPageSize()
        {
            //Arrange
            //Act
            _ordersListViewModel.PageSize = PageSize;

            //Assert
            Assert.Equal(PageSize, _ordersListViewModel.PageSize);
        }

        [Fact]
        public void TestSetGetPageIndex()
        {
            //Arrange
            //Act
            _ordersListViewModel.PageIndex = PageIndex;

            //Assert
            Assert.Equal(PageIndex, _ordersListViewModel.PageIndex);
        }

        [Fact]
        public void TestSetGetNumberOfPages()
        {
            //Arrange
            //Act
            _ordersListViewModel.NumberOfPages = NumberOfPages;

            //Assert
            Assert.Equal(NumberOfPages, _ordersListViewModel.NumberOfPages);
        }

        [Fact]
        public void TestSetGetHasNextPage()
        {
            //Arrange
            //Act
            _ordersListViewModel.HasNextPage = HasNextPage;

            //Assert
            Assert.Equal(HasNextPage, _ordersListViewModel.HasNextPage);
        }

        [Fact]
        public void TestSetGetHasPrevPage()
        {
            //Arrange
            //Act
            _ordersListViewModel.HasPrevPage = HasPrevPage;

            //Assert
            Assert.Equal(HasPrevPage, _ordersListViewModel.HasPrevPage);
        }

        [Fact]
        public void TestSetGetTotalNumberOfOrders()
        {
            //Arrange
            //Act
            _ordersListViewModel.TotalNumberOfOrders = TotalNumberOfOrders;

            //Assert
            Assert.Equal(TotalNumberOfOrders, _ordersListViewModel.TotalNumberOfOrders);
        }

        [Fact]
        public void TestSetGetOrdersPageRatio()
        {
            //Arrange
            //Act
            _ordersListViewModel.OrdersPageRatio = OrdersPageRatio;

            //Assert
            Assert.Equal(OrdersPageRatio, _ordersListViewModel.OrdersPageRatio);
        }
    }
}
