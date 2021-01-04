using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Shared;
using Scrutor;

namespace Persistence
{
    public static class PersistenceServices
    {
        public static IServiceCollection AddPersistenceServiceCollection(this IServiceCollection services,
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

            return services;
        }
    }
}