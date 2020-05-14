using Moq;
using Persistence.Categories;
using Persistence.Shared;
using Xunit;

namespace PersistenceTests.Categories
{
    public class CategoryRepositoryTests
    {
        [Fact]
        public void TestConstructorShouldCreateRepository()
        {
            //Arrange
            var mockCategoryRepository = new Mock<IDatabaseContext>();
            //Act
            var sut = new CategoryRepository(mockCategoryRepository.Object);
            //Assert
            Assert.NotNull(sut);
        }
    }
}