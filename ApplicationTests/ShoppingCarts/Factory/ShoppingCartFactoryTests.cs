

using System.Collections.Generic;
using System.Linq;
using Application.Categories.Queries.GetCategoryList;
using Application.ShoppingCartItems.Queries;
using Application.ShoppingCarts.Factory;
using Application.ShoppingCarts.Queries;
using Domain.ShopItems;
using Domain.ShoppingCartItems;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using Xunit;

namespace ApplicationTests.ShoppingCarts.Factory
{
    public class ShoppingCartFactoryTests
    {
        public ShoppingCartFactoryTests()
        {
            _shoppingCartItem1 = new ShoppingCartItem
            {
                Id = 1,
                Amount = 1,
                ShopItem = new ShopItem
                {
                    Id = 1,
                    Name = "Item1"
                },
                ShoppingCartId = "TestCartId"
            };

            _shoppingCartItem2 = new ShoppingCartItem
            {
                Id = 2,
                Amount = 2,
                ShopItem = new ShopItem
                {
                    Id = 2,
                    Name = "Item2"
                },
                ShoppingCartId = "TestCartId"
            };

            var shoppingCartItem3 = new ShoppingCartItem
            {
                Id = 3,
                Amount = 1,
                ShopItem = new ShopItem
                {
                    Id = 3,
                    Name = "Item3"
                },
                ShoppingCartId = "DifferentTestCardId"
            };


            _shoppingCartItems = new List<ShoppingCartItem>
            {
                _shoppingCartItem1,
                _shoppingCartItem2,
                shoppingCartItem3
            };
        }

        private readonly List<ShoppingCartItem> _shoppingCartItems;
        private readonly ShoppingCartItem _shoppingCartItem1;
        private readonly ShoppingCartItem _shoppingCartItem2;
        [Fact]
        public void CreateShouldCreateNewShoppingCartWithCorrectId()
        {
            //Arrange
            const string cartId = "uniqueCartId";
            var expectedShoppingCart = new ShoppingCart(cartId);

            var mockGetShoppingCartItems = new Mock<IGetShoppingCartItemsQuery>();



            var sut = new ShoppingCartFactory(mockGetShoppingCartItems.Object);

            //Act

            var result = sut.Create(cartId);

            //Assert

            Assert.Equal(expectedShoppingCart.CartId,result.CartId);


        }
    }
}
