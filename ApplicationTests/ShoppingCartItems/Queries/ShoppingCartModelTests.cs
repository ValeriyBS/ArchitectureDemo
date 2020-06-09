using System;
using System.Collections.Generic;
using System.Text;
using Application.ShoppingCartItems.Queries;
using Domain.ShopItems;
using Domain.ShoppingCartItems;
using Xunit;

namespace Application.Tests.ShoppingCartItems.Queries
{
    public class ShoppingCartModelTests
    {
        private readonly ShoppingCartModel _sut;

        public ShoppingCartModelTests()
        {
            _sut = new ShoppingCartModel("testCartId")
            {
                ShoppingCartItems = new List<ShoppingCartItem>()
                {
                    new ShoppingCartItem()
                    {
                        Amount = 2,
                        ShopItem = new ShopItem()
                        {
                            Price = 1.1m
                        }
                    },
                    new ShoppingCartItem()
                    {
                        Amount = 3,
                        ShopItem = new ShopItem()
                        {
                            Price = 1.2m
                        }
                    }
                }

            };
        }
        [Fact]
        public void TestShoppingCartTotalReturnsSumOfItemsPrice()
        {
            //Arrange
            const decimal expectedShoppingCartTotal = 5.8m;

            //Act
            var result = _sut.ShoppingCartTotal;

            //Assert

            Assert.Equal(expectedShoppingCartTotal,result);
        }

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
    }
}
