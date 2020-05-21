using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Common.AutoFac;
using Common.Dates;

namespace Application.AutoFac
{
    public static class ApplicationContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<CommonModule>();
            builder.RegisterModule<ApplicationModule>();

            return builder.Build();
        }
    }
}
