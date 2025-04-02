using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppUI.DependencyResolvers
{
    public static class IocContainer
    {
        public static IContainer Container { get; private set; }

        public static void Build()
        {
            var services = new ServiceCollection();
            services.AddDependencyResolvers(new ICoreModule[]
            {
                new CoreModule()
            });

            var builder = new ContainerBuilder();

            builder.Populate(services);

            // Business katmanındaki DI konfigürasyonlarını al
            builder.RegisterModule(new AutofacBusinessModule());

            // Diğer özel bağımlılıklar varsa burada tanımlanabilir
            // builder.RegisterType<SomeHelper>().As<ISomeHelper>();

            Container = builder.Build();
            ServiceTool.ServiceProvider = services.BuildServiceProvider();
        }
    }
}
