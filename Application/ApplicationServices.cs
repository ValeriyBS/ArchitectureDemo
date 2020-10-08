using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace Application
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServiceCollection(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationServices));
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
