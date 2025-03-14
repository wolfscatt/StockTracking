using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.CastleDynamicProxy.CacheAspects
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheService _cacheService;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheService = ServiceTool.ServiceProvider.GetService<ICacheService>();
        }

        public override void OnBefore(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_cacheService.IsAdd(key))
            {
                var data = _cacheService.Get(key);
                invocation.ReturnValue = data;
                return;
            }
            _cacheService.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
