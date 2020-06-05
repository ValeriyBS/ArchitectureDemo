using System;
using System.Linq;
using Domain.Categories;
using Domain.ShopItems;
using Domain.ShoppingCartItems;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence.Shared;
using Persistence.ShoppingCartItems;
using Xunit;
using Xunit.Abstractions;

namespace Persistence.Tests.ShoppingCartItems
{
    public class ShoppingCartItemRepositoryTests
    {
        private readonly ITestOutputHelper _output;
        private readonly DatabaseContext _context;

        public ShoppingCartItemRepositoryTests(ITestOutputHelper output)
        {
            _output = output;

            var connectionStringBuilder =
                new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            var connection = new SqliteConnection(connectionStringBuilder.ToString());

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseLoggerFactory(new LoggerFactory(
                    new[] { new LogToActionLoggerProvider((log) =>
                    {
                        _output.WriteLine(log);
                    }) }))
                .UseSqlite(connection)
                .Options;

            _context = new DatabaseContext(options);

            _context.Database.OpenConnection();
            _context.Database.EnsureCreated();

            _context.Categories.Add(new Category()
            {
                Id = 999,
                Name = "TestCategory"
            });

            _context.ShopItems.Add(new ShopItem()
            {
                CategoryId = 999,
                Id = 999,
                Name = "TestShopItem"
            });

            _context.SaveChanges();

            
        }


        [Fact]
        public void TestGetAllShouldReturnAllShoppingCartItemsIncludingShopItemProperty()
        {
            //Arrange
            var uniqueId = Guid.NewGuid().ToString();

            var expectedShoppingCartItem = new ShoppingCartItem()
            {
                Id = 999,
                Amount = 1,
                ShopItemId = 1,
                ShopItem = new ShopItem()
                {
                    CategoryId = 999,
                    Id = 999,
                    Name = "TestShopItem"
                },
                ShoppingCartId = uniqueId
            };

            const int expectedShopItemId = 999;

            _context.ShoppingCartItems.Add(new ShoppingCartItem()
            {
                    Id = 999,
                    Amount = 1,
                    ShopItemId = 999,
                    ShoppingCartId = uniqueId
            });

            _context.SaveChanges();

            var sut = new ShoppingCartItemRepository(_context);

            //Act

            var result = sut.GetAll();

            var resultShopItemId = result.FirstOrDefault(s => s.ShoppingCartId == uniqueId)?.ShopItemId;

            //Assert

            Assert.Contains(expectedShoppingCartItem, result);

            Assert.Equal(expectedShopItemId,resultShopItemId);
        }

        [Fact]
        public void TestAddShouldIncreaseTheAmountIfEntityExists()
        {
            //Arrange
            const int expectedShoppingCartItemsCount = 1;
            const int expectedShoppingCartItemsAmount = 2;
            var uniqueId = Guid.NewGuid().ToString();

            var shoppingCartItem = new ShoppingCartItem()
            {
                Id = 999,
                ShopItemId = 999,
                ShopItem = new ShopItem()
                {
                    Id = 999,
                    Name = "TestItem",
                    CategoryId = 999
                },
                ShoppingCartId = uniqueId,
                Amount = 1
            };

           

            var sut = new ShoppingCartItemRepository(_context);

            //Act

            sut.Add(shoppingCartItem);
            sut.Add(shoppingCartItem);


            var result = sut.GetAll().Where(s=>s.ShoppingCartId == uniqueId);

            //Assert

            Assert.Equal(expectedShoppingCartItemsCount,result.Count());

            Assert.Equal(expectedShoppingCartItemsAmount, result.First().Amount);
        }

        [Fact]
        public void TestAddShouldThrowsArgumentNullExceptionWhenShopItemIsNull()
        {
            //Arrange
            var uniqueId = Guid.NewGuid().ToString();

            var shoppingCartItem = new ShoppingCartItem()
            {
                Id = 999,
                ShopItemId = 999,
                ShopItem = null!,
                ShoppingCartId = uniqueId,
                Amount = 1
            };

            var sut = new ShoppingCartItemRepository(_context);
            //Act
            Assert.Throws<ArgumentNullException>(
                //Assert
                () => sut.Add(shoppingCartItem));
        }

        [Fact]
        public void TestAddShouldThrowsArgumentNullExceptionWhenShoppingCartIdIsNull()
        {
            //Arrange

            var shoppingCartItem = new ShoppingCartItem()
            {
                Id = 999,
                ShopItemId = 999,
                ShopItem = new ShopItem()
                {
                    Id = 999,
                    Name = "TestItem",
                    CategoryId = 999
                },
                ShoppingCartId = null!,
                Amount = 1
            };

            var sut = new ShoppingCartItemRepository(_context);
            //Act
            Assert.Throws<ArgumentNullException>(
                //Assert
                () => sut.Add(shoppingCartItem));
        }

        [Fact]
        public void TestAddShouldThrowsArgumentExceptionWhenShopItemWithShopItemIdNotFound()
        {
            //Arrange
            var uniqueId = Guid.NewGuid().ToString();
            const string expectedExceptionMessage = "Shop Item not found with ShopItemId";

            var shoppingCartItem = new ShoppingCartItem()
            {
                Id = 999,
                ShopItemId = 99,
                ShopItem = new ShopItem()
                {
                    Id = 999,
                    Name = "TestItem",
                    CategoryId = 999
                },
                ShoppingCartId = uniqueId,
                Amount = 1
            };

            var sut = new ShoppingCartItemRepository(_context);
            //Act
            var exception = Assert.Throws<ArgumentException>(
                //Assert
                () => sut.Add(shoppingCartItem));

            Assert.Equal(expectedExceptionMessage,exception.Message);

        }

        [Fact]
        public void TestRemoveShouldRemoveEntityIfOnlyOneExists()
        {
            //Arrange
            var uniqueId = Guid.NewGuid().ToString();
            var expectedShoppingCartItem = new ShoppingCartItem()
            {
                ShopItemId = 999,
                ShoppingCartId = uniqueId
            };

            _context.ShoppingCartItems.Add(new ShoppingCartItem()
            {
                Id = 999,
                ShopItemId = 999,
                ShoppingCartId = uniqueId,
                Amount = 1
            });

            _context.SaveChanges();

            var sut = new ShoppingCartItemRepository(_context);

            //Act

            sut.Remove(new ShoppingCartItem()
            {
                ShopItemId = 999,
                ShoppingCartId = uniqueId
            });

            var result = sut.GetAll();

            //Assert

            Assert.DoesNotContain(expectedShoppingCartItem,result);
        }

        [Fact]
        public void TestRemoveShouldReduceAmountIfMoreThanOneExists()
        {
            //Arrange
            const int expectedShoppingCartItemsAmount = 5;

            var uniqueId = Guid.NewGuid().ToString();

            var expectedShoppingCartItem = new ShoppingCartItem()
            {
                Id = 999,
                ShopItemId = 999,
                ShoppingCartId = uniqueId
            };

            var shoppingCartItem = new ShoppingCartItem()
            {
                Id = 999,
                ShopItemId = 999,
                ShoppingCartId = uniqueId,
                Amount = 6
            };

            _context.ShoppingCartItems.Add(shoppingCartItem);

            _context.SaveChanges();

            var sut = new ShoppingCartItemRepository(_context);

            //Act

            sut.Remove(new ShoppingCartItem()
            {
                ShopItemId = 999,
                ShoppingCartId = uniqueId
            });

            var result = sut.GetAll();


            //Assert

            Assert.Contains(expectedShoppingCartItem, result);

            Assert.Equal(expectedShoppingCartItemsAmount, result.First().Amount);
        }
    }
}
