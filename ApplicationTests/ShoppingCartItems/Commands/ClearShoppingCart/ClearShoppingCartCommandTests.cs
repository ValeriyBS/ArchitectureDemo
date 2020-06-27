using System;
using Application.Interfaces.Persistence;
using Application.ShoppingCartItems.Commands.ClearShoppingCart;
using Moq;
using Xunit;

namespace Application.Tests.ShoppingCartItems.Commands.ClearShoppingCart
{
    public class ClearShoppingCartCommandTests
    {
        public ClearShoppingCartCommandTests()
        {
            _mockShoppingCartItemRepository = new Mock<IShoppingCartItemRepository>();

            _sut = new ClearShoppingCartCommand(_mockShoppingCartItemRepository.Object);
        }

        private readonly Mock<IShoppingCartItemRepository> _mockShoppingCartItemRepository;
        private readonly ClearShoppingCartCommand _sut;

        [Fact]
        public void TestExecuteShouldClearShoppingCart()
        {
            //Arrange
            const string testCartId = "testCartId";

            //Act
            _sut.Execute(testCartId);

            //Assert
            _mockShoppingCartItemRepository.Verify(s => s.Clear(testCartId), Times.Once);
        }

        [Fact]
        public void TestExecuteShouldThrowArgumentNullExceptionWhenCartIdIsNull()
        {
            //Arrange
            //Act
            Assert.Throws<ArgumentNullException>(
                //Assert
                () => _sut.Execute(null!));
        }
    }
}