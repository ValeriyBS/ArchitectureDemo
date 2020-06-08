using Application.Categories.Queries.GetCategoryList;
using Application.ShopItems.Queries.GetShopItemsList;
using Application.ShoppingCartItems.Commands;
using Application.ShoppingCartItems.Queries;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class Startup
    {
        public static void ConfigureServices(
            IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IGetCategoryListQuery, GetCategoryListQuery>();
            services.AddScoped<IGetShopItemsListQuery, GetShopItemsListQuery>();
            services.AddScoped<IGetShopItemsListByCategoryQuery, GetShopItemsListByCategoryQuery>();
            services.AddScoped<IGetShoppingCartItemsListQuery, GetShoppingCartItemsListQuery>();
            services.AddScoped<IAddShoppingCartItemCommand, AddShoppingCartItemCommand>();
            services.AddScoped<IRemoveShoppingCartItemCommand, RemoveShoppingCartItemCommand>();
        }
    }
}