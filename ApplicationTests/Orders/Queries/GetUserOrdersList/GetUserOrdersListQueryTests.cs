using System;
using Application.Interfaces.Persistence;
using Application.Orders.Queries.GetUserOrdersList;
using AutoFixture;
using Moq;
using Xunit;

namespace Application.Tests.Orders.Queries.GetUserOrdersList
{
    public class GetUserOrdersListQueryTests
    {
        [Fact]
        public void TestExecuteShouldReturnListOfOrders()
        {
            //Arrange
            var fixture = new Fixture();
            var testUserId = fixture.Create<string>();
            var mockOrderRepository = new Mock<IOrderRepository>();
            var sut = new GetUserOrdersListQuery(mockOrderRepository.Object);

            //Act
            sut.Execute(testUserId);

            //Assert
            mockOrderRepository.Verify(o => o.GetByUserId(testUserId), Times.Once);
        }

        [Fact]
        public void TestExecuteShouldThrowArgumentNullExceptionWhenUserIdNull()
        {
            //Arrange
            var mockOrderRepository = new Mock<IOrderRepository>();
            var sut = new GetUserOrdersListQuery(mockOrderRepository.Object);

            //Act
            Assert.Throws<ArgumentNullException>(
                //Assert
                () => sut.Execute(null!));
        }
    }
}