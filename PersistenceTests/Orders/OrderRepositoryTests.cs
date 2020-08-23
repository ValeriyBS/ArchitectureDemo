using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Customers;
using Domain.OrderDetails;
using Domain.Orders;
using Domain.ShopItems;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Persistence.Orders;
using Persistence.Shared;
using Xunit;
using Xunit.Abstractions;

namespace Persistence.Tests.Orders
{
    public class OrderRepositoryTests
    {
        public OrderRepositoryTests(ITestOutputHelper output)
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

            context.SaveChanges();
        }

        private readonly DbContextOptions<DatabaseContext> _options;


        [Fact]
        public void TestAddShouldAddOrderToTheDatabase()
        {
            //Arrange
            using (var context = new DatabaseContext(_options))
            {
                var order = new Order
                {
                    OrderDetails = new List<OrderDetail>
                    {
                        new OrderDetail {ShopItemId = 1, Price = 1},
                        new OrderDetail {ShopItemId = 2, Price = 2}
                    },
                    Customer = new Customer {UserId = "userId"},
                    OrderPlaced = DateTime.UtcNow,
                    OrderTotal = 1010
                };

                context.Orders.Add(order);

                context.SaveChanges();
            }

            //Act
            using (var context = new DatabaseContext(_options))
            {
                var result = context.Orders
                    .Include(o => o.OrderDetails).Include(o => o.Customer);

                //Assert
                Assert.NotNull(result.FirstOrDefault(o => o.OrderTotal == 1010));
            }
        }

        [Fact]
        public void TestAddShouldAddOrderToTheDatabaseInDisconnectedScenario()
        {
            //Arrange
            using (var context = new DatabaseContext(_options))
            {
                var order = new Order
                {
                    OrderDetails = new List<OrderDetail>
                    {
                        new OrderDetail {ShopItemId = 1, Price = 1},
                        new OrderDetail {ShopItemId = 2, Price = 2}
                    },
                    Customer = new Customer {UserId = "userId"},
                    OrderPlaced = DateTime.UtcNow,
                    OrderTotal = 1010
                };

                var orderRepository = new OrderRepository(context);
                orderRepository.Add(order);
            }

            using (var context = new DatabaseContext(_options))
            {
                context.SaveChanges();
            }


            //Act
            using (var context = new DatabaseContext(_options))
            {
                var result = context.Orders
                    .Include(o => o.OrderDetails).Include(o => o.Customer);

                //Assert
                Assert.Null(result.FirstOrDefault(o => o.OrderTotal == 1010));
            }
        }

        [Fact]
        public void TestConstructorShouldCreateRepository()
        {
            //Arrange
            var mockOrderRepository = new Mock<IDatabaseContext>();
            //Act
            var sut = new OrderRepository(mockOrderRepository.Object);
            //Assert
            Assert.NotNull(sut);
        }

        [Fact]
        public void TestGetByUserIdShouldReturnCompleteOrdersGraphList()
        {
            //Arrange
            const int expectedOrdersCount = 1;
            const int expectedOrderDetailsCount = 2;
            const string expectedUserId = "testUserId";
            const string expectedFirstItemName = "Item1";
            const string expectedSecondItemName = "Item2";

            using (var context = new DatabaseContext(_options))
            {
                var order = new Order
                {
                    OrderDetails = new List<OrderDetail>
                    {
                        new OrderDetail {Price = 1, ShopItem = new ShopItem {Name = "Item1"}},
                        new OrderDetail {Price = 2, ShopItem = new ShopItem {Name = "Item2"}}
                    },
                    Customer = new Customer {UserId = "testUserId"},
                    OrderPlaced = DateTime.UtcNow,
                    OrderTotal = 1010
                };
                var order1 = new Order
                {
                    OrderDetails = new List<OrderDetail>
                    {
                        new OrderDetail {Price = 3, ShopItem = new ShopItem {Name = "Item3"}},
                        new OrderDetail {Price = 4, ShopItem = new ShopItem {Name = "Item4"}}
                    },
                    Customer = new Customer {UserId = "testUserId1"},
                    OrderPlaced = DateTime.UtcNow,
                    OrderTotal = 1010
                };

                context.Orders.AddRange(order, order1);

                context.SaveChanges();
            }

            using (var context = new DatabaseContext(_options))
            {
                var sut = new OrderRepository(context);

                //Act
                var orders = sut.GetByUserId("testUserId");
                var result = orders.FirstOrDefault();
                //Assert
                Assert.Equal(expectedOrdersCount, orders.Count);
                Assert.Equal(expectedUserId, result.Customer.UserId);
                Assert.Equal(expectedOrderDetailsCount, result.OrderDetails.Count);
                Assert.Equal(expectedFirstItemName, result.OrderDetails[0].ShopItem.Name);
                Assert.Equal(expectedSecondItemName, result.OrderDetails[1].ShopItem.Name);
            }
        }
    }
}