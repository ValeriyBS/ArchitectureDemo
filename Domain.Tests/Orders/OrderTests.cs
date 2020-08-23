using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using Domain.Customers;
using Domain.OrderDetails;
using Domain.Orders;
using Tests.Core.AutoFixture;
using Xunit;

namespace Domain.Tests.Orders
{
    public class OrderTests
    {
        public OrderTests()
        {
            var fixture = new OmitRecursionFixture();

            _orderDetails = fixture.CreateMany<OrderDetail>().ToList();

            _customer = fixture.Create<Customer>();

            _orderPlaced = fixture.Create<DateTime>();

            _order = new Order();
        }

        private readonly List<OrderDetail> _orderDetails;
        private readonly Order _order;
        private readonly Customer _customer;
        private readonly DateTime _orderPlaced;
        private const decimal OrderTotal = 1.1m;
        private const int Id = 2;

        [Fact]
        public void TestSetGetCustomer()
        {
            //Arrange
            //Act
            _order.Customer = _customer;

            //Assert
            Assert.Equal(_customer, _order.Customer);
        }

        [Fact]
        public void TestSetGetId()
        {
            //Arrange
            //Act
            _order.Id = Id;

            //Assert
            Assert.Equal(Id, _order.Id);
        }

        [Fact]
        public void TestSetGetOrderDetails()
        {
            //Arrange
            //Act
            _order.OrderDetails = _orderDetails;

            //Assert
            Assert.Equal(_orderDetails, _order.OrderDetails);
        }

        [Fact]
        public void TestSetGetOrderPlaced()
        {
            //Arrange
            //Act
            _order.OrderPlaced = _orderPlaced;

            //Assert
            Assert.Equal(_orderPlaced, _order.OrderPlaced);
        }

        [Fact]
        public void TestSetGetOrderTotal()
        {
            //Arrange
            //Act
            _order.OrderTotal = OrderTotal;

            //Assert
            Assert.Equal(OrderTotal, _order.OrderTotal);
        }
    }
}