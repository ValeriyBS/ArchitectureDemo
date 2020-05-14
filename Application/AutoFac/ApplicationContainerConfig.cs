using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace Application.AutoFac
{
    public static class ApplicationContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            return builder.Build();
        }
    }
}
