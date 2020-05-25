using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.AutoFac;
using Application.Categories.Queries.GetCategoryList;
using Application.Interfaces.Persistence;
using Application.ShoppingCarts.Factory;
using Application.ShoppingCarts.Queries;
using Autofac;
using Domain.Categories;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence.AutoFac;
using Persistence.Categories;
using Persistence.Shared;
using Presentation.ShoppingCarts.Services.Queries;

namespace Presentation
{
   
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
           

            services.Configure<RazorViewEngineOptions>(o =>
            {
                // {2} is area, {1} is controller,{0} is the action    
                o.ViewLocationFormats.Clear();
                o.ViewLocationFormats.Add("/{1}/Views/{0}" + RazorViewEngine.ViewExtension);
                o.ViewLocationFormats.Add("/Shared/Views/{0}" + RazorViewEngine.ViewExtension);
                //o.ViewLocationFormats.Add("/Controllers/Shared/Views/{0}" + RazorViewEngine.ViewExtension);

                // Untested. You could remove this if you don't care about areas.
                //o.AreaViewLocationFormats.Clear();
                //o.AreaViewLocationFormats.Add("/Areas/{2}/Controllers/{1}/Views/{0}" + RazorViewEngine.ViewExtension);
                //o.AreaViewLocationFormats.Add("/Areas/{2}/Controllers/Shared/Views/{0}" + RazorViewEngine.ViewExtension);
                //o.AreaViewLocationFormats.Add("/Areas/Shared/Views/{0}" + RazorViewEngine.ViewExtension);
            });

            services.AddScoped<GetShoppingCart>(GetShoppingCart.Execute);
            services.AddHttpContextAccessor();
            services.AddControllersWithViews();
            services.AddSession();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }

                app.UseHttpsRedirection();
                app.UseStaticFiles();
                app.UseSession();

                app.UseRouting();
                //app.UseAuthentication();
                //app.UseAuthorization();

                //app.UseStaticFiles();// points to for static files wwwroot

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(name: "default",
                        pattern: "{controller=Home}/{action=Index}/{Id?}");
                    //endpoints.MapRazorPages();
                });
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<PersistenceModule>();
            builder.RegisterModule<ApplicationModule>();
            //builder.RegisterType<ShoppingCart>().WithParameter(""," GetShoppingCart.Execute(sp)");
        }
    }
}
