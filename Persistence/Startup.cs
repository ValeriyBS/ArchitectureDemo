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
using Scrutor;

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
            services.Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses()
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        }
    }
}
