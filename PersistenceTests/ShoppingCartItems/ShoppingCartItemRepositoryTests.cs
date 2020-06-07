using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Categories;
using Domain.ShopItems;
using Domain.ShoppingCartItems;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Persistence.Shared;
using Persistence.ShoppingCartItems;
using Xunit;
using Xunit.Abstractions;

namespace Persistence.Tests.ShoppingCartItems
{
    public class ShoppingCartItemRepositoryTests
    {
        public ShoppingCartItemRepositoryTests(ITestOutputHelper output)
        {
            var connectionStringBuilder =
                new SqliteConnectionStringBuilder {DataSource = ":memory:"};
            var connection = new SqliteConnection(connectionStringBuilder.ToString());

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .EnableSensitiveDataLogging()
                .UseLoggerFactory(new LoggerFactory(
                    new[] {new LogToActionLoggerProvider(output.WriteLine)}))
                .UseSqlite(connection)
                .Options;

            _options = options;

            using var context = new DatabaseContext(options);

            context.Database.OpenConnection();

            context.Database.EnsureCreated();

            context.Categories.Add(new Category
            {
                Id = 999,
                Name = "TestCategory",
                ShopItems = new List<ShopItem>
                {
                    new ShopItem
                    {
                        CategoryId = 999,
                        Id = 999,
                        Name = "TestShopItem"
                    }
                }
            });

            context.SaveChanges();
        }

        //private readonly DatabaseContext _context;
        private readonly DbContextOptions<DatabaseContext> _options;

        [Fact]
        public void TestAddShouldIncreaseTheAmountIfEntityExists()
        {
            //Arrange
            const int expectedShoppingCartItemsCount = 1;
            const int expectedShoppingCartItemsAmount = 2;
            var uniqueId = Guid.NewGuid().ToString();

            var shoppingCartItem = new ShoppingCartItem
            {
                Id = 999,
                ShopItemId = 999,
                ShopItem = new ShopItem
                {
                    Id = 999,
                    Name = "TestItem",
                    CategoryId = 999
                },
                ShoppingCartId = uniqueId,
                Amount = 1
            };


            using var context = new DatabaseContext(_options);

            var sut = new ShoppingCartItemRepository(context);

            //Act

            sut.Add(shoppingCartItem);
            sut.Add(shoppingCartItem);


            var result = sut.GetAll().Where(s => s.ShoppingCartId == uniqueId);

            //Assert

            Assert.Equal(expectedShoppingCartItemsCount, result.Count());

            Assert.Equal(expectedShoppingCartItemsAmount, result.First().Amount);
        }

        [Fact]
        public void TestAddShouldThrowsArgumentExceptionWhenShopItemWithShopItemIdNotFound()
        {
            //Arrange
            var uniqueId = Guid.NewGuid().ToString();
            const string expectedExceptionMessage = "Shop Item not found with ShopItemId";

            var shoppingCartItem = new ShoppingCartItem
            {
                Id = 999,
                ShopItemId = 99,
                ShopItem = new ShopItem
                {
                    Id = 999,
                    Name = "TestItem",
                    CategoryId = 999
                },
                ShoppingCartId = uniqueId,
                Amount = 1
            };

            var mockDatabaseContext = new DatabaseContext(_options);

            var sut = new ShoppingCartItemRepository(mockDatabaseContext);
            //Act
            var exception = Assert.Throws<ArgumentException>(
                //Assert
                () => sut.Add(shoppingCartItem));

            Assert.Equal(expectedExceptionMessage, exception.Message);
        }

        [Fact]
        public void TestAddShouldThrowsArgumentNullExceptionWhenShopItemIsNull()
        {
            //Arrange
            var uniqueId = Guid.NewGuid().ToString();

            var shoppingCartItem = new ShoppingCartItem
            {
                Id = 999,
                ShopItemId = 999,
                ShopItem = null!,
                ShoppingCartId = uniqueId,
                Amount = 1
            };

            var mockDatabaseContext = new Mock<IDatabaseContext>();

            var sut = new ShoppingCartItemRepository(mockDatabaseContext.Object);
            //Act
            Assert.Throws<ArgumentNullException>(
                //Assert
                () => sut.Add(shoppingCartItem));
        }

        [Fact]
        public void TestAddShouldThrowsArgumentNullExceptionWhenShoppingCartIdIsNull()
        {
            //Arrange

            var shoppingCartItem = new ShoppingCartItem
            {
                Id = 999,
                ShopItemId = 999,
                ShopItem = new ShopItem
                {
                    Id = 999,
                    Name = "TestItem",
                    CategoryId = 999
                },
                ShoppingCartId = null!,
                Amount = 1
            };

            var mockDatabaseContext = new Mock<IDatabaseContext>();

            var sut = new ShoppingCartItemRepository(mockDatabaseContext.Object);
            //Act
            Assert.Throws<ArgumentNullException>(
                //Assert
                () => sut.Add(shoppingCartItem));
        }


        [Fact]
        public void TestGetAllShouldReturnAllShoppingCartItemsIncludingShopItemProperty()
        {
            //Arrange
            var uniqueId = Guid.NewGuid().ToString();

            var expectedShoppingCartItem = new ShoppingCartItem
            {
                Id = 999,
                Amount = 1,
                ShopItemId = 999,
                ShopItem = new ShopItem
                {
                    CategoryId = 999,
                    Id = 999,
                    Name = "TestShopItem"
                },
                ShoppingCartId = uniqueId
            };

            using (var context = new DatabaseContext(_options))
            {
                var shopItem = context.ShopItems.Find(999);

                context.ShoppingCartItems.Add(new ShoppingCartItem
                {
                    Id = 999,
                    Amount = 1,
                    ShopItem = shopItem,
                    ShoppingCartId = uniqueId
                });

                context.SaveChanges();
            }

            using (var context = new DatabaseContext(_options))
            {
                var sut = new ShoppingCartItemRepository(context);

                //Act

                var result = sut.GetAll();

                //Assert

                Assert.Contains(expectedShoppingCartItem, result);
            }
        }

        [Fact]
        public void TestRemoveShouldReduceAmountIfMoreThanOneExists()
        {
            //Arrange
            var uniqueId = Guid.NewGuid().ToString();

            var expectedShoppingCartItem = new ShoppingCartItem
            {
                Id = 999,
                ShopItemId = 999,
                ShoppingCartId = uniqueId,
                Amount = 5
            };


            using (var context = new DatabaseContext(_options))
            {
                var shopItem = context.ShopItems.Find(999);
                context.ShoppingCartItems.Add(new ShoppingCartItem
                {
                    Id = 999,
                    ShopItem = shopItem,
                    ShoppingCartId = uniqueId,
                    Amount = 6
                });

                context.SaveChanges();
            }

            using (var context = new DatabaseContext(_options))
            {
                var sut = new ShoppingCartItemRepository(context);

                //Act

                sut.Remove(new ShoppingCartItem
                {
                    ShopItemId = 999,
                    ShoppingCartId = uniqueId
                });

                var result = sut.GetAll();


                //Assert

                Assert.Contains(expectedShoppingCartItem, result);
            }
        }

        [Fact]
        public void TestRemoveShouldRemoveEntityIfOnlyOneExists()
        {
            //Arrange
            var uniqueId = Guid.NewGuid().ToString();

            using (var context = new DatabaseContext(_options))
            {
                var shopItem = context.ShopItems.Find(999);
                context.ShoppingCartItems.Add(new ShoppingCartItem
                {
                    Id = 999,
                    ShopItem = shopItem,
                    ShoppingCartId = uniqueId,
                    Amount = 1
                });

                context.SaveChanges();
            }


            using (var context = new DatabaseContext(_options))
            {
                var sut = new ShoppingCartItemRepository(context);

                //Act

                sut.Remove(new ShoppingCartItem
                {
                    ShopItemId = 999,
                    ShoppingCartId = uniqueId
                });

                var result = sut.GetAll();

                //Assert

                Assert.Empty(result);
            }
        }

        [Fact]
        public void TestRemoveShouldReturnVoidIfItemDoesNotExist()
        {
            //Arrange
            var uniqueId = Guid.NewGuid().ToString();

            var mockDatabaseContext = new Mock<IDatabaseContext>();


            mockDatabaseContext.Setup(c => c.ShopItems.Find(999))
                .Returns(new ShopItem
                {
                    Id = 999,
                    CategoryId = 999
                });

                mockDatabaseContext.Setup(c => c.ShoppingCartItems)
                    .Returns(new DatabaseContext(_options).ShoppingCartItems);

            var sut = new ShoppingCartItemRepository(mockDatabaseContext.Object);

            //Act

            sut.Remove(new ShoppingCartItem
            {
                ShopItemId = 999,
                ShoppingCartId = uniqueId
            });


            //Assert

            mockDatabaseContext.Verify(d => d.ShoppingCartItems, Times.Once);
        }

        [Fact]
        public void TestRemoveShouldThrowArgumentNullExceptionIfShoppingCartItemIsNull()
        {
            //Arrange

            var mockDatabaseContext = new Mock<IDatabaseContext>();

            var sut = new ShoppingCartItemRepository(mockDatabaseContext.Object);

            //Act

            Assert.Throws<ArgumentNullException>(
                //Assert
                () => sut.Remove(null!));
        }
    }
}