using Castle.DynamicProxy;

namespace Core.Aspects.CastleDynamicProxy.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, System.Reflection.MethodInfo method, IInterceptor[] interceptors)
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
