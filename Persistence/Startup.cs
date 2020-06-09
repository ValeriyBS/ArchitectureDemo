using System.Diagnostics.CodeAnalysis;
using Application.Interfaces.Persistence;
using Domain.Categories;
using Domain.ShopItems;
using Domain.ShoppingCartItems;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Categories;
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
        }
    }
}
