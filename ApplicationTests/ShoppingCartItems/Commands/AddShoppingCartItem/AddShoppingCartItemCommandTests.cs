using System;
using Application.Interfaces.Persistence;
using Application.ShoppingCartItems.Commands.AddShoppingCartItem;
using Domain.ShoppingCartItems;
using Moq;
using Xunit;

namespace Application.Tests.ShoppingCartItems.Commands.AddShoppingCartItem
{
    public class AddShoppingCartItemCommandTests
    {
        public AddShoppingCartItemCommandTests()
        {
            _mockShoppingCartItemRepository = new Mock<IShoppingCartItemRepository>();

            _sut = new AddShoppingCartItemCommand(_mockShoppingCartItemRepository.Object);
        }

        private readonly AddShoppingCartItemCommand _sut;
        private readonly Mock<IShoppingCartItemRepository> _mockShoppingCartItemRepository;

        [Fact]
        public void TestExecuteShouldAddShoppingCartItem()
        {
            //Arrange
            const int testShopItemId = 1;
            const string testCartId = "testCartId";

            //Act
            _sut.Execute(testShopItemId, testCartId);

            //Assert
            _mockShoppingCartItemRepository.Verify(
                s => s.Add(It.Is<ShoppingCartItem>(
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