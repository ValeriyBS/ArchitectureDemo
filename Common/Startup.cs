using System.Diagnostics.CodeAnalysis;
using Common.Dates;
using Microsoft.Extensions.DependencyInjection;

namespace Common
{
    [ExcludeFromCodeCoverage]
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDateTimeService, DateTimeService>();
        }
    }
}