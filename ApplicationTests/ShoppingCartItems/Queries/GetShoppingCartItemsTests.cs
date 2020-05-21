using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;
using Application.ShoppingCartItems.Queries;
using Domain.ShopItems;
using Domain.ShoppingCartItems;
using Microsoft.VisualBasic;
using Xunit;
using Moq;

namespace ApplicationTests.ShoppingCartItems.Queries
{
    public class GetShoppingCartItemsTests
    {
        [Fact]
        public void ExecuteShouldReturnShoppingItems()
        {
            //arrange
            const string testCartId = "TestCartId";

            var mockShoppingCartItemRepository = new Mock<IShoppingCartItemRepository>();

            var shoppingCartItem1 = new ShoppingCartItem()
            {
                Id = 1,
                Amount = 1,
                ShopItem = new ShopItem()
                {
                    Id = 1,
                    Name = "Item1"
                },
                ShoppingCartId = "TestCartId"
            };

            var shoppingCartItem2 = new ShoppingCartItem()
            {
                Id = 2,
                Amount = 2,
                ShopItem = new ShopItem()
                {
                    Id = 2,
                    Name = "Item2"
                },
                ShoppingCartId = "TestCartId"
            };

            var shoppingCartItem3 = new ShoppingCartItem()
            {
                Id = 3,
                Amount = 1,
                ShopItem = new ShopItem()
                {
                    Id = 3,
                    Name = "Item3"
                },
                ShoppingCartId = "DifferentTestCardId"
            };


           var shoppingCartItems = new List<ShoppingCartItem>()
            {
                shoppingCartItem1,
                shoppingCartItem2,
                shoppingCartItem3
            };

           var expectedShoppingCartItems = new List<ShoppingCartItem>()
           {
               shoppingCartItem1,
               shoppingCartItem2
           };


            mockShoppingCartItemRepository.Setup(s => s.GetAll()).Returns(shoppingCartItems.AsQueryable);

            var sut = new GetShoppingCartItems(mockShoppingCartItemRepository.Object);
            //act

            var resultShoppingCartItems = sut.Execute(testCartId);
            //assert

            Assert.Equal(expectedShoppingCartItems,resultShoppingCartItems);

        }
    }
}
