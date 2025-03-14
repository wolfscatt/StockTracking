using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes(typeof(MethodInterceptionBaseAttribute), true)
                .Cast<MethodInterceptionBaseAttribute>()
                .ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes(typeof(MethodInterceptionBaseAttribute), true)
                .Cast<MethodInterceptionBaseAttribute>();
            if(methodAttributes != null)
            {
                classAttributes.AddRange(methodAttributes);
            }
            return classAttributes
               .OrderBy(attr => attr.Priority) // Priority'ye göre sıralama
               .ToArray();
        }
    }
}
