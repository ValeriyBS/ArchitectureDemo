using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation.Areas.Identity;
using Presentation.Areas.Identity.Data;
using Presentation.Orders.Services.Commands.SaveApplicationUser;
using Presentation.Orders.Services.Queries.GetApplicationUser;
using Presentation.ShoppingCarts.Services.Queries;

namespace Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RazorViewEngineOptions>(o =>
            {
                // {2} is area, {1} is controller,{0} is the action    
                o.ViewLocationFormats.Clear();
                o.ViewLocationFormats.Add("/{1}/Views/{0}" + RazorViewEngine.ViewExtension);
                o.ViewLocationFormats.Add("/Shared/Views/{0}" + RazorViewEngine.ViewExtension);
                o.AreaPageViewLocationFormats.Clear();
                o.AreaPageViewLocationFormats.Add("/Shared/Views/{1}/{0}" + RazorViewEngine.ViewExtension);
                //o.AreaPageViewLocationFormats.Add("/Shared/Views/Components/{0}" + RazorViewEngine.ViewExtension);
                //o.ViewLocationFormats.Add("/Controllers/Shared/Views/{0}" + RazorViewEngine.ViewExtension);

                // Untested. You could remove this if you don't care about areas.
                //o.AreaViewLocationFormats.Clear();
                //o.AreaViewLocationFormats.Add("/Areas/{2}/Controllers/{1}/Views/{0}" + RazorViewEngine.ViewExtension);
                //o.AreaViewLocationFormats.Add("/Areas/{2}/Controllers/Shared/Views/{0}" + RazorViewEngine.ViewExtension);
                //o.AreaViewLocationFormats.Add("/Areas/Shared/Views/{0}" + RazorViewEngine.ViewExtension);
            });

            // Common module startup
            Common.Startup.ConfigureServices(services);

            // Persistence module startup
            Persistence.Startup.ConfigureServices(services, Configuration.GetConnectionString("DefaultConnection"));

            //Application module startup
            Application.Startup.ConfigureServices(services);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("ApplicationConnection")));

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped(CartIdProvider.Execute);
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IGetApplicationUserDetails, GetApplicationUserDetails>();
            services.AddScoped<IGetApplicationUserId, GetApplicationUserId>();
            services.AddScoped<ISaveApplicationUserDetails, SaveApplicationUserDetails>();

            services.AddHttpContextAccessor();
            services.AddSession();
            services.AddControllersWithViews();
            services.AddRazorPages();
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default",
                    "{controller=Home}/{action=Index}/{Id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}