using Application.Interfaces.Persistence;
using Autofac;
using Common.Dates;
using Domain.Categories;
using Domain.ShopItems;
using Persistence.Categories;
using Persistence.Shared;
using Persistence.ShopItems;

namespace Persistence.AutoFac
{
    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DatabaseContext>().As<IDatabaseContext>().SingleInstance();

            builder.RegisterType<Repository<Category>>().As<IRepository<Category>>().InstancePerDependency();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().InstancePerDependency();

            builder.RegisterType<Repository<ShopItem>>().As<IRepository<ShopItem>>().InstancePerDependency();
            builder.RegisterType<ShopItemRepository>().As<IShopItemRepository>().InstancePerDependency();
        }
    }
}