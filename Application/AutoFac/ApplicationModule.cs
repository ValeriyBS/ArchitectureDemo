using Application.Categories.Queries.GetCategoryList;
using Application.ShopItems.Queries.GetShopItemsList;
using Application.ShoppingCartItems.Commands;
using Application.ShoppingCartItems.Queries;
using Application.ShoppingCarts.Factory;
using Application.ShoppingCarts.Queries;
using Autofac;

namespace Application.AutoFac
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GetCategoryListQuery>().As<IGetCategoryListQuery>().InstancePerDependency();
            builder.RegisterType<GetShopItemsListQuery>().As<IGetShopItemsListQuery>().InstancePerDependency();
            builder.RegisterType<GetShoppingCartItemsListQuery>().As<IGetShoppingCartItemsListQuery>().InstancePerDependency();
            builder.RegisterType<ShoppingCartFactory>().As<IShoppingCartFactory>().InstancePerDependency();
            builder.RegisterType<ShoppingCart>().As<IShoppingCart>().InstancePerLifetimeScope();
            builder.RegisterType<AddShoppingCartItemCommand>().As<IAddShoppingCartItemCommand>()
                .InstancePerLifetimeScope();
            builder.RegisterType<RemoveShoppingCartItemCommand>().As<IRemoveShoppingCartItemCommand>()
                .InstancePerLifetimeScope();
            builder.RegisterType<GetShopItemsListByCategoryQuery>().As<IGetShopItemsListByCategoryQuery>()
                .InstancePerDependency();
        }
    }
}