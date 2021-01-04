using Application.Interfaces.Infrastructure;
using Infrastructure.Inventory;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServiceCollection(this IServiceCollection services)
        {
            services.AddScoped<IInventoryService, InventoryService>();

            return services;
        }
    }
}