using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;
using Application.ShoppingCartItems.Queries;
using Domain.ShopItems;
using Domain.ShoppingCartItems;
using Moq;
using Xunit;

namespace Application.Tests.ShoppingCartItems.Queries
{
    public class GetShoppingCartItemsListQueryTests
    {
        public GetShoppingCartItemsListQueryTests()
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
        public void TestExecuteShouldReturnNoItemsIfNoShoppingCartIdMatchesFound()
        {
            //arrange
            const string testCartId = "NoMatchesId";

            var mockShoppingCartItemRepository = new Mock<IShoppingCartItemRepository>();


            mockShoppingCartItemRepository
                .Setup(s => s.GetAll())
                .Returns(_shoppingCartItems.AsQueryable);

            var sut = new GetShoppingCartItemsListQuery(mockShoppingCartItemRepository.Object);

            //act
            var results = sut.Execute(testCartId);

            //assert
            Assert.Empty(results);
        }

        [Fact]
        public void TestExecuteShouldReturnShoppingItems()
        {
            //arrange
            const string testCartId = "TestCartId";

            var mockShoppingCartItemRepository = new Mock<IShoppingCartItemRepository>();


            var expectedShoppingCartItems = new List<ShoppingCartItem>
            {
                _shoppingCartItem1,
                _shoppingCartItem2
            };


            mockShoppingCartItemRepository.Setup(s => s.GetAll()).Returns(_shoppingCartItems.AsQueryable);

            var sut = new GetShoppingCartItemsListQuery(mockShoppingCartItemRepository.Object);

            //act
            var results = sut.Execute(testCartId);

            //assert
            Assert.Equal(expectedShoppingCartItems, results);
        }
    }
}