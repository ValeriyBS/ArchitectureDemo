using Common.Dates;
using Microsoft.Extensions.DependencyInjection;

namespace Common
{
    public static class CommonServices
    {
        public static IServiceCollection AddCommonServiceCollection(this IServiceCollection services)
        {
            services.AddScoped<IDateTimeService, DateTimeService>();

            return services;
        }
    }
}