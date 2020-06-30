using Moq;
using Persistence.OrderDetails;
using Persistence.Shared;
using Xunit;

namespace Persistence.Tests.OrderDetails
{
    public class OrderDetailRepositoryTests
    {
        [Fact]
        public void TestConstructorShouldCreateRepository()
        {
            //Arrange
            var mockOrderDetailRepository = new Mock<IDatabaseContext>();
            //Act
            var sut = new OrderDetailRepository(mockOrderDetailRepository.Object);
            //Assert
            Assert.NotNull(sut);
        }
    }
}