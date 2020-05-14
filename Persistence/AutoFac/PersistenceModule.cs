using Application.Interfaces.Persistence;
using Autofac;
using Domain.Categories;
using Persistence.Shared;

namespace Persistence.AutoFac
{
    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Repository<Category>>().As<IRepository<Category>>().InstancePerDependency();
        }
    }
}