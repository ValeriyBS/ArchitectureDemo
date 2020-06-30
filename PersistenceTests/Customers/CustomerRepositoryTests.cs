using Moq;
using Persistence.Customers;
using Persistence.Shared;
using Xunit;

namespace Persistence.Tests.Customers
{
    public class CustomerRepositoryTests
    {
        [Fact]
        public void TestConstructorShouldCreateRepository()
        {
            //Arrange
            var mockCustomerRepository = new Mock<IDatabaseContext>();
            //Act
            var sut = new CustomerRepository(mockCustomerRepository.Object);
            //Assert
            Assert.NotNull(sut);
        }
    }
}