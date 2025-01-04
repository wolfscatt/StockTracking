using Castle.DynamicProxy;
using Core.Aspects.CastleDynamicProxy.Interceptors;
using Core.CrossCuttingConcerns.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.CastleDynamicProxy.CacheAspects
{
    public class CacheAspect : MethodInterception
    {
        private Type _cacheType;
        private int _duration;
        private ICacheService _cacheService;

        public CacheAspect(Type cacheType, int duration = 60)
        {
            _cacheType = cacheType;
            _duration = duration;
        }

        public override void RuntimeInitialize()
        {
            if(typeof(ICacheService).IsAssignableFrom(_cacheType) == false)
            {
                throw new Exception("Wrong Cache Manager");
            }

            _cacheService = (ICacheService)Activator.CreateInstance(_cacheType);
        }

        public override void OnBefore(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.Namespace}.{invocation.Method.ReflectedType.Name}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_cacheService.IsAdd(key))
            {
                var data = _cacheService.Get<object>(key);
                invocation.ReturnValue = data;
                return;
            }
            _cacheService.Add(key, invocation.ReturnValue, _duration);
        }
    }

    public class CacheRemoveAspect : MethodInterception
    {
        private Type _cacheType;
        private string _pattern;
        private ICacheService _cacheService;
        public CacheRemoveAspect(Type cacheType, string pattern)
        {
            _cacheType = cacheType;
            _pattern = pattern;
        }
        public CacheRemoveAspect(Type cacheType)
        {
            _cacheType = cacheType;
        }
        public override void RuntimeInitialize()
        {
            if (typeof(ICacheService).IsAssignableFrom(_cacheType) == false)
            {
                throw new Exception("Wrong Cache Manager");
            }
            _cacheService = (ICacheService)Activator.CreateInstance(_cacheType);
        }
        public override void OnSuccess(IInvocation invocation)
        {
            _cacheService.RemoveByPattern(string.IsNullOrEmpty(_pattern) 
                ? string.Format($"{invocation.Method.ReflectedType.Namespace}.{invocation.Method.ReflectedType.Name}.*") 
                : _pattern);
        }
    }
}
