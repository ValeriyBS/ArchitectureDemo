using System.Diagnostics.CodeAnalysis;
using Application.Categories.Queries.GetCategoryList;
using Application.Orders.Commands.CreateOrder;
using Application.Orders.Commands.CreateOrder.Factory;
using Application.Orders.Commands.CreateOrder.Repository;
using Application.Orders.Commands.CreateOrdersListViewModel.Factory;
using Application.Orders.Queries.GetUserOrdersList;
using Application.ShopItems.Queries.GetShopItemsList;
using Application.ShopItems.Queries.GetShopItemsListByCategory;
using Application.ShoppingCartItems.Commands.AddShoppingCartItem;
using Application.ShoppingCartItems.Commands.ClearShoppingCart;
using Application.ShoppingCartItems.Commands.RemoveShoppingCartItem;
using Application.ShoppingCartItems.Queries.GetShoppingCartItemsList;
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