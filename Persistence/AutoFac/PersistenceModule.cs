using Application.Interfaces.Persistence;
using Autofac;
using Domain.Categories;
using Persistence.Categories;
using Persistence.Shared;

namespace Persistence.AutoFac
{
    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DatabaseContext>().As<IDatabaseContext>().SingleInstance();
            builder.RegisterType<Repository<Category>>().As<IRepository<Category>>().InstancePerDependency();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().InstancePerDependency();
        }
    }
}