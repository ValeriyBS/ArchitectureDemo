using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Interfaces.Persistence;
using Application.ShoppingCartItems.Commands.ClearShoppingCart;
using Application.ShoppingCartItems.Commands.RemoveShoppingCartItem;
using Domain.ShoppingCartItems;
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
        public void TestExecuteShouldRemoveShoppingCartItem()
        {
            //Arrange
            const int testShopItemId = 1;
            const string testCartId = "testCartId";
            _mockShoppingCartItemRepository.Setup(s => s.GetAll()).Returns(new List<ShoppingCartItem>().AsQueryable());

            //Act
            _sut.Execute(testCartId);

            //Assert
            
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
