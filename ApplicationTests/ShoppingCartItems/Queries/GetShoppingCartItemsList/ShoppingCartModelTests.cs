using System.Collections.Generic;
using System.Linq;
using Application.ShoppingCartItems.Queries.GetShoppingCartItemsList;
using AutoFixture;
using Domain.ShoppingCartItems;
using Xunit;

namespace Application.Tests.ShoppingCartItems.Queries.GetShoppingCartItemsList
{
    public class ShoppingCartModelTests
    {
        public ShoppingCartModelTests()
        {
            var fixture = new Fixture();

            // client has a circular reference from AutoFixture point of view
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            _shoppingCartItems = fixture.CreateMany<ShoppingCartItem>(3).ToList();

            _sut = new ShoppingCartModel("testCartId")
            {
                ShoppingCartItems = _shoppingCartItems
            };
        }

        private readonly ShoppingCartModel _sut;
        private readonly List<ShoppingCartItem> _shoppingCartItems;

        [Fact]
        public void TestShoppingCartItemsCountShouldReturnNumberOfShoppingCartItems()
        {
            //Arrange
            var expectedShoppingCartItemsNumber = _shoppingCartItems.Sum(i => i.Amount);

            //Act
            var result = _sut.ShoppingCartItemsCount;

            //Assert
            Assert.Equal(expectedShoppingCartItemsNumber, result);
        }

        [Fact]
        public void TestShoppingCartModelShouldReturnCartId()
        {
            //Arrange
            const string expectedCartId = "testCartId";

            //Act
            var result = _sut.CartId;

            //Assert
            Assert.Equal(expectedCartId, result);
        }

        [Fact]
        public void TestShoppingCartTotalShouldReturnSumOfItemsPrice()
        {
            //Arrange
            var expectedShoppingCartTotal = _shoppingCartItems.Sum(i => i.ShopItem.Price * i.Amount);

            //Act
            var result = _sut.ShoppingCartTotal;

            //Assert
            Assert.Equal(expectedShoppingCartTotal, result);
        }
    }
}