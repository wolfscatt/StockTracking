using Castle.DynamicProxy;

namespace Core.Aspects.CastleDynamicProxy.Interceptors
{
    public class MethodInterception : MethodInterceptionBaseAttribute
    {
        public override void Intercept(IInvocation invocation)
        {
            bool isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                isSuccess = false;
                OnException(invocation, ex);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }

        public virtual void RuntimeInitialize()
        {
            Console.WriteLine("Runtime Initialize Method is Running...");
        }

        public virtual void OnBefore(IInvocation invocation)
        {
            Console.WriteLine("MethodInterception is executing before...");
        }

        public virtual void OnAfter(IInvocation invocation)
        {
            Console.WriteLine("MethodInterception is executing after...");
        }

        public virtual void OnException(IInvocation invocation, Exception ex)
        {
            Console.WriteLine("MethodInterception is executing on exception...");
        }

        public virtual void OnSuccess(IInvocation invocation)
        {
            Console.WriteLine("MethodInterception is executing on success...");
        }
    }
}
