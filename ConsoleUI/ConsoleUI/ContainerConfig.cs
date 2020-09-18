using Autofac;
using Autofac.Builder;
using CoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ConsoleUI
{
    public static class ContainerConfig
    {
        public static IContainer configure()
        {
            var builder = new ContainerBuilder();

            //Single registration of dependencies
            builder.RegisterType<Application>().As<IApplication>();
            //builder.RegisterType<BusinessLogic>().As<IBusinessLogic>();

            //Multiple registration of dependencies placed in the same folder
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(CoreLibrary)))
                .Where(t => t.Namespace.Contains(nameof(CoreLibrary)))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(CoreLibrary)))
                .Where(t => t.Namespace.Contains(nameof(CoreLibrary.Utilities)))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            return builder.Build();
        }
    }
}
