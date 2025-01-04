using Castle.DynamicProxy;
using Core.Aspects.CastleDynamicProxy.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Aspects.CastleDynamicProxy.TransactionAspects
{
    public class TransactionScopeAspect : MethodInterception
    {
        private readonly TransactionScopeOption _transactionScopeOption;
        private TransactionScope _transactionScope;
        public TransactionScopeAspect(TransactionScopeOption transactionScopeOption)
        {
            _transactionScopeOption = transactionScopeOption;
        }
        public TransactionScopeAspect()
        {
            
        }

        // Metot başlamadan önce TransactionScope başlatılır
        public override void OnBefore(IInvocation invocation)
        {
            _transactionScope = new TransactionScope(_transactionScopeOption,
                new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TransactionManager.MaximumTimeout
                });
            Console.WriteLine("TransactionScope started.");
        }

        // Metot başarıyla tamamlanırsa TransactionScope commit edilir
        public override void OnSuccess(IInvocation invocation)
        {
            _transactionScope?.Complete();
            Console.WriteLine("TransactionScope completed successfully.");
        }

        // Hata durumunda TransactionScope rollback edilir
        public override void OnException(IInvocation invocation, Exception ex)
        {
            Console.WriteLine($"TransactionScope rolled back due to an error: {ex.Message}");
            // Rollback işlemi zaten otomatik olarak yapılır (Complete çağrılmazsa rollback olur)
        }

        // Metot tamamlandıktan sonra TransactionScope dispose edilir
        public override void OnAfter(IInvocation invocation)
        {
            _transactionScope?.Dispose();
            Console.WriteLine("TransactionScope disposed.");
        }
    }
}
