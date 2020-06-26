using Moq;
using Persistence.Shared;
using Persistence.ShopItems;
using Xunit;

namespace Persistence.Tests.ShopItems
{
    public class ShopItemRepositoryTests
    {
        [Fact]
        public void TestConstructorShouldCreateRepository()
        {
            //Arrange
            var mockShopItemRepository = new Mock<IDatabaseContext>();
            //Act
            var sut = new ShopItemRepository(mockShopItemRepository.Object);
            //Assert
            Assert.NotNull(sut);
        }
    }
}