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

        public ShoppingCartItemRepositoryTests(ITestOutputHelper output)
        {
            _output = output;
        }


        [Fact]
        public void TestGetAllShouldReturnAllShoppingCartItemsIncludingShopItemProperty()
        {
            //Arrange
            var expectedShoppingCartItem = new ShoppingCartItem()
            {
                Id = 1,
                Amount = 1,
                ShopItemId = 1,
                ShoppingCartId = "UniqueId"
            };

            const int expectedShopItemId = 999;

            var uniqueId = Guid.NewGuid().ToString();


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

            using var context = new DatabaseContext(options);

            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            context.Categories.Add(new Category()
            {
                Id = 999,
                Name = "TestCategory"
            });

            context.ShopItems.Add(new ShopItem()
            {
                CategoryId = 999,
                Id = 999,
                Name = "TestShopItem"
            });

            context.ShoppingCartItems.Add(new ShoppingCartItem()
            {
                    Amount = 1,
                    ShopItemId = 999,
                    ShoppingCartId = uniqueId
            });

            context.SaveChanges();

            var sut = new ShoppingCartItemRepository(context);

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

            using var context = new DatabaseContext(options);

            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            context.Categories.Add(new Category()
            {
                Id = 999,
                Name = "TestCategory"
            });

            context.ShopItems.Add(new ShopItem()
            {
                CategoryId = 999,
                Id = 999,
                Name = "TestShopItem"
            });

            context.SaveChanges();


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

           

            var sut = new ShoppingCartItemRepository(context);

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

            var connectionStringBuilder =
                new SqliteConnectionStringBuilder {DataSource = ":memory:"};
            var connection = new SqliteConnection(connectionStringBuilder.ToString());

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseLoggerFactory(new LoggerFactory(
                    new[] {new LogToActionLoggerProvider((log) => { _output.WriteLine(log); })}))
                .UseSqlite(connection)
                .Options;

            using var context = new DatabaseContext(options);
            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            context.Categories.Add(new Category()
            {
                Id = 999,
                Name = "TestCategory"
            });

            context.ShopItems.Add(new ShopItem()
            {
                CategoryId = 999,
                Id = 999,
                Name = "TestShopItem"
            });

            context.SaveChanges();

            var shoppingCartItem = new ShoppingCartItem()
            {
                Id = 999,
                ShopItemId = 999,
                ShopItem = null!,
                ShoppingCartId = uniqueId,
                Amount = 1
            };

            var sut = new ShoppingCartItemRepository(context);
            //Act
            Assert.Throws<ArgumentNullException>(
                //Assert
                () => sut.Add(shoppingCartItem));
        }

        [Fact]
        public void TestAddShouldThrowsArgumentNullExceptionWhenShoppingCartIdisNull()
        {
            //Arrange

            var connectionStringBuilder =
                new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            var connection = new SqliteConnection(connectionStringBuilder.ToString());

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseLoggerFactory(new LoggerFactory(
                    new[] { new LogToActionLoggerProvider((log) => { _output.WriteLine(log); }) }))
                .UseSqlite(connection)
                .Options;

            using var context = new DatabaseContext(options);
            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            context.Categories.Add(new Category()
            {
                Id = 999,
                Name = "TestCategory"
            });

            context.ShopItems.Add(new ShopItem()
            {
                CategoryId = 999,
                Id = 999,
                Name = "TestShopItem"
            });

            context.SaveChanges();

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

            var sut = new ShoppingCartItemRepository(context);
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
            var expectedExceptionMessage = "Shop Item not found with ShopItemId";

            var connectionStringBuilder =
                new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            var connection = new SqliteConnection(connectionStringBuilder.ToString());

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseLoggerFactory(new LoggerFactory(
                    new[] { new LogToActionLoggerProvider((log) => { _output.WriteLine(log); }) }))
                .UseSqlite(connection)
                .Options;

            using var context = new DatabaseContext(options);
            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            context.Categories.Add(new Category()
            {
                Id = 999,
                Name = "TestCategory"
            });

            context.ShopItems.Add(new ShopItem()
            {
                CategoryId = 999,
                Id = 999,
                Name = "TestShopItem"
            });

            context.SaveChanges();

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

            var sut = new ShoppingCartItemRepository(context);
            //Act
            var exception = Assert.Throws<ArgumentException>(
                //Assert
                () => sut.Add(shoppingCartItem));

            Assert.Equal(expectedExceptionMessage,exception.Message);

        }



    }

}
