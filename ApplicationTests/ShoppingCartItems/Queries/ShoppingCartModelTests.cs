using System.Collections.Generic;
using Application.ShoppingCartItems.Queries;
using Domain.ShopItems;
using Domain.ShoppingCartItems;
using Xunit;

namespace Application.Tests.ShoppingCartItems.Queries
{
    public class ShoppingCartModelTests
    {
        public ShoppingCartModelTests()
        {
            _sut = new ShoppingCartModel("testCartId")
            {
                ShoppingCartItems = new List<ShoppingCartItem>
                {
                    new ShoppingCartItem
                    {
                        Amount = 2,
                        ShopItem = new ShopItem
                        {
                            Price = 1.1m
                        }
                    },
                    new ShoppingCartItem
                    {
                        Amount = 3,
                        ShopItem = new ShopItem
                        {
                            Price = 1.2m
                        }
                    }
                }
            };
        }

        private readonly ShoppingCartModel _sut;

        [Fact]
        public void TestShoppingCartItemsCountReturnsNumberOfShoppingCartItems()
        {
            //Arrange
            const int expectedShoppingCartItemsNumber = 5;

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
        public void TestShoppingCartTotalReturnsSumOfItemsPrice()
        {
            //Arrange
            const decimal expectedShoppingCartTotal = 5.8m;

            //Act
            var result = _sut.ShoppingCartTotal;

            //Assert
            Assert.Equal(expectedShoppingCartTotal, result);
        }
    }
}