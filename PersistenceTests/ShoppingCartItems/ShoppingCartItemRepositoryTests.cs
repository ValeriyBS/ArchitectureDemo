using System.Collections.Generic;
using System.Linq;
using Domain.Categories;
using Domain.ShopItems;
using Domain.ShoppingCartItems;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Moq;
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
                ShopItem = new ShopItem()
                {
                    Id = 1,
                    Name = "ItemName"
                },
                ShoppingCartId = "UniqueId"
            };

            const int expectedShopItemId = 999;


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
                    ShoppingCartId = "UniqueId"
            });

            context.SaveChanges();

            var shoppingCartItemRepository = new ShoppingCartItemRepository(context);



            //Act

            var result = shoppingCartItemRepository.GetAll();

            var resultShopItemId = result.FirstOrDefault(s => s.ShoppingCartId == "UniqueId")?.ShopItemId;

            //Assert

            Assert.Contains(expectedShoppingCartItem, result);

            Assert.Equal(expectedShopItemId,resultShopItemId);


        }
    }

}
