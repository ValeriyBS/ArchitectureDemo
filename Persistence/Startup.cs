using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Shared;
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