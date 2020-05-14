using System;
using System.Collections.Generic;
using System.Text;
using Application.Interfaces.Persistence;
using Autofac;

namespace Application.AutoFac
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<CategoryRepository>().As<ICategoryRepository>>().Instance
        }
    }
}
