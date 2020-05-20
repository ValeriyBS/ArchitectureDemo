using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Common.Dates;

namespace Common.AutoFac
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DateTimeService>().As<IDateTimeService>().InstancePerDependency();
        }
    }
}
