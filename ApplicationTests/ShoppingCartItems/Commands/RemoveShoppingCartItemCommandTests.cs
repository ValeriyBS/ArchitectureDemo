using System;
using Application.Interfaces.Persistence;
using Application.ShoppingCartItems.Commands;
using Domain.ShoppingCartItems;
using Moq;
using Xunit;

namespace Application.Tests.ShoppingCartItems.Commands
{
    public class RemoveShoppingCartItemCommandTests
    {
        public RemoveShoppingCartItemCommandTests()
        {
            _mockShoppingCartItemRepository = new Mock<IShoppingCartItemRepository>();

            _sut = new RemoveShoppingCartItemCommand(_mockShoppingCartItemRepository.Object);
        }

        private readonly Mock<IShoppingCartItemRepository> _mockShoppingCartItemRepository;
        private readonly RemoveShoppingCartItemCommand _sut;

        [Fact]
        public void TestExecuteShouldRemoveShoppingCartItem()
        {
            //Arrange
            const int testShopItemId = 1;
            const string testCartId = "testCartId";

            //Act
            _sut.Execute(testShopItemId, testCartId);

            //Assert
            _mockShoppingCartItemRepository.Verify(
                s => s.Remove(It.Is<ShoppingCartItem>(
                    i => i.ShopItemId == testShopItemId && i.ShoppingCartId == testCartId)), Times.Once);
        }

        [Fact]
        public void TestExecuteShouldThrowArgumentNullExceptionWhenCartIdIsNull()
        {
            //Arrange
            //Act
            Assert.Throws<ArgumentNullException>(
                //Assert
                () => _sut.Execute(It.IsAny<int>(), null!));
        }
    }
}