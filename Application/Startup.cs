using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace Application
{
    [ExcludeFromCodeCoverage]
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses()
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        }
    }
}