using System;
using System.Collections.Generic;
using System.Text;
using Application.Categories.Queries.GetCategoryList;
using Application.Interfaces.Persistence;
using Application.ShopItems.Queries.GetShopItemsList;
using Application.ShoppingCartItems.Commands;
using Application.ShoppingCartItems.Queries;
using Application.ShoppingCarts.Factory;
using Application.ShoppingCarts.Queries;
using Domain.ShopItems;
using Domain.ShoppingCartItems;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class Startup
    {
        public static void ConfigureServices(
            IServiceCollection services)
        {
            services.AddScoped<IGetCategoryListQuery, GetCategoryListQuery>();
            services.AddScoped<IGetShopItemsListQuery, GetShopItemsListQuery>();
            services.AddScoped<IGetShopItemsListByCategoryQuery, GetShopItemsListByCategoryQuery>();
            services.AddScoped<IGetShoppingCartItemsListQuery, GetShoppingCartItemsListQuery>();
            //services.AddScoped<IShoppingCartFactory, ShoppingCartFactory>();
            //services.AddScoped<IShoppingCart, ShoppingCart>();
            services.AddScoped<IAddShoppingCartItemCommand, AddShoppingCartItemCommand>();
            services.AddScoped<IRemoveShoppingCartItemCommand, RemoveShoppingCartItemCommand>();




            //builder.RegisterType<GetCategoryListQuery>().As<IGetCategoryListQuery>().InstancePerDependency();
            //builder.RegisterType<GetShopItemsListQuery>().As<IGetShopItemsListQuery>().InstancePerDependency();
            //builder.RegisterType<GetShoppingCartItemsListQuery>().As<IGetShoppingCartItemsListQuery>().InstancePerDependency();
            //builder.RegisterType<ShoppingCartFactory>().As<IShoppingCartFactory>().InstancePerDependency();
            //builder.RegisterType<ShoppingCart>().As<IShoppingCart>().InstancePerLifetimeScope();
            //builder.RegisterType<AddShoppingCartItemCommand>().As<IAddShoppingCartItemCommand>()
            //    .InstancePerLifetimeScope();
            //builder.RegisterType<RemoveShoppingCartItemCommand>().As<IRemoveShoppingCartItemCommand>()
            //    .InstancePerLifetimeScope();
            //builder.RegisterType<GetShopItemsListByCategoryQuery>().As<IGetShopItemsListByCategoryQuery>()
            //    .InstancePerDependency();
        }
    }
}
