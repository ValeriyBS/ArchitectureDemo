using Microsoft.AspNetCore.Hosting;
using Presentation.Areas.Identity;

[assembly: HostingStartup(typeof(IdentityHostingStartup))]

namespace Presentation.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => { });
        }
    }
}