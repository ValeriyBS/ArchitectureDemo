using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;
using Application.ShoppingCartItems.Queries.GetShoppingCartItemsList;
using AutoFixture;
using Domain.ShoppingCartItems;
using Moq;
using Xunit;

namespace Application.Tests.ShoppingCartItems.Queries.GetShoppingCartItemsList
{
    public class GetShoppingCartItemsListQueryTests
    {
        public GetShoppingCartItemsListQueryTests()
        {
            var fixture = new Fixture();

            // client has a circular reference from AutoFixture point of view
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            _shoppingCartItems = fixture.CreateMany<ShoppingCartItem>().ToList();
            _shoppingCartItems.First().ShoppingCartId = "TestCartId";
            _shoppingCartItems.Last().ShoppingCartId = "TestCartId";
        }

        private readonly List<ShoppingCartItem> _shoppingCartItems;

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
                _shoppingCartItems.First(),
                _shoppingCartItems.Last()
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