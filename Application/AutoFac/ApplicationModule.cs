using System;
using System.Collections.Generic;
using System.Text;
using Application.Categories.Queries.GetCategoryList;
using Application.Interfaces.Persistence;
using Application.ShopItems.Queries.GetShopItemsList;
using Application.ShoppingCartItems.Queries;
using Autofac;

namespace Application.AutoFac
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GetCategoryListQuery>().As<IGetCategoryListQuery>().InstancePerDependency();
            builder.RegisterType<GetShopItemsListQuery>().As<IGetShopItemsListQuery>().InstancePerDependency();
            builder.RegisterType<GetShoppingCartItemsQuery>().As<IGetShoppingCartItemsQuery>().InstancePerDependency();
        }
    }
}
