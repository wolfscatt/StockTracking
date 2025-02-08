using Autofac.Core;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {

            // Burada başka Servisler için IoC Container'a eklemeler yapabiliriz.
            services.AddSingleton<ICacheService, MemoryCacheManager>();
            services.AddSingleton<Stopwatch>();
        }
    }
}
