using System.Diagnostics.CodeAnalysis;
using Application.Categories.Queries.GetCategoryList;
using Application.Interfaces.Infrastructure;
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

namespace Application
{
    [ExcludeFromCodeCoverage]
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IGetCategoryListQuery, GetCategoryListQuery>();
            services.AddScoped<IGetShopItemsListQuery, GetShopItemsListQuery>();
            services.AddScoped<IGetShopItemsListByCategoryQuery, GetShopItemsListByCategoryQuery>();
            services.AddScoped<IGetShoppingCartItemsListQuery, GetShoppingCartItemsListQuery>();
            services.AddScoped<IAddShoppingCartItemCommand, AddShoppingCartItemCommand>();
            services.AddScoped<IRemoveShoppingCartItemCommand, RemoveShoppingCartItemCommand>();
            services.AddScoped<IOrderRepositoryFacade, OrderRepositoryFacade>();
            services.AddScoped<IOrderFactory, OrderFactory>();
            services.AddScoped<ICreateOrderCommand, CreateOrderCommand>();
            services.AddScoped<IClearShoppingCartCommand, ClearShoppingCartCommand>();
            services.AddScoped<IGetUserOrdersListQuery,GetUserOrdersListQuery>(); 
            services.AddScoped<IOrdersListViewModelFactory, OrdersListViewModelFactory>();
            services.AddScoped<IInventoryService, IInventoryService>();
        }
    }
}