using Application.Interfaces.Infrastructure;
using Infrastructure.Inventory;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IInventoryService, InventoryService>();
        }
    }
}