using System.Diagnostics.CodeAnalysis;
using Application.Interfaces.Persistence;
using Domain.Categories;
using Domain.Customers;
using Domain.OrderDetails;
using Domain.Orders;
using Domain.ShopItems;
using Domain.ShoppingCartItems;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Categories;
using Persistence.Customers;
using Persistence.OrderDetails;
using Persistence.Orders;
using Persistence.Shared;
using Persistence.ShopItems;
using Persistence.ShoppingCartItems;

namespace Persistence
{
    [ExcludeFromCodeCoverage]
    public static class Startup
    {
        public static void ConfigureServices(
            IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IDatabaseContext, DatabaseContext>();
            services.AddScoped<IRepository<Category>, Repository<Category>>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IRepository<ShopItem>, Repository<ShopItem>>();
            services.AddScoped<IShopItemRepository, ShopItemRepository>();
            services.AddScoped<IRepository<ShoppingCartItem>, Repository<ShoppingCartItem>>();
            services.AddScoped<IShoppingCartItemRepository, ShoppingCartItemRepository>();
            services.AddScoped<IRepository<Order>, Repository<Order>>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IRepository<OrderDetail>, Repository<OrderDetail>>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IRepository<Customer>, Repository<Customer>>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


        }
    }
}
