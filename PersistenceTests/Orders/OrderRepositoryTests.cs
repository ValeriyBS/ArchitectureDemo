using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Customers;
using Domain.OrderDetails;
using Domain.Orders;
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
        private readonly DbContextOptions<DatabaseContext> _options;

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
        public void TestAddShouldAddOrderToTheDatabase()
        {
            //Arrange
            using (var context = new DatabaseContext(_options))
            {
                var order = new Order()
                {
                    OrderDetails = new List<OrderDetail>()
                    {
                        new OrderDetail(){ShopItemId = 1, Price =1},
                        new OrderDetail(){ShopItemId = 2, Price = 2}
                    },
                    Customer = new Customer(){FirstName = "Gordon",LastName = "Freeman"},
                    OrderPlaced = DateTime.UtcNow,
                    OrderTotal = 1010
                };

                context.Orders.Add(order);

                var changes = context.ChangeTracker.Entries();

                foreach (var entry in changes)
                {
                    var entryName = entry.Entity.GetType().Name;
                    var entryState = entry.State.ToString();
                }

                context.SaveChanges();
            }
            //Act
            using (var context = new DatabaseContext(_options))
            {
                var result = context.Orders
                    .Include(o=>o.OrderDetails).
                    Include(o=>o.Customer);

                //Assert
                Assert.NotNull(result.FirstOrDefault(o=>o.OrderTotal == 1010));
            }
        }

        [Fact]
        public void TestAddShouldAddOrderToTheDatabase1()
        {
            //Arrange
            using (var context = new DatabaseContext(_options))
            {
                var order = new Order()
                {
                    OrderDetails = new List<OrderDetail>()
                    {
                        new OrderDetail(){ShopItemId = 1, Price =1},
                        new OrderDetail(){ShopItemId = 2, Price = 2}
                    },
                    Customer = new Customer() { FirstName = "Gordon", LastName = "Freeman" },
                    OrderPlaced = DateTime.UtcNow,
                    OrderTotal = 1010
                };

                var orderRepository = new OrderRepository(context);
                orderRepository.Add(order);

                var changes = context.ChangeTracker.Entries();

                foreach (var entry in changes)
                {
                    var entryName = entry.Entity.GetType().Name;
                    var entryState = entry.State.ToString();
                }
            }

            using (var context = new DatabaseContext(_options))
            {
                context.SaveChanges();
            }



            //Act
            using (var context = new DatabaseContext(_options))
            {
                var result = context.Orders
                    .Include(o => o.OrderDetails).
                    Include(o => o.Customer);

                //Assert
                Assert.NotNull(result.FirstOrDefault(o => o.OrderTotal == 1010));
            }
        }
    }
}