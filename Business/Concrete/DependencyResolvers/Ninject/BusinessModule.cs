using Business.Abstract;
using Business.Concrete.Managers;
using Castle.DynamicProxy;
using Core.Aspects.CastleDynamicProxy.Interceptors;
using DataAccess.Abstract;
using DataAccess.Abstract.IRepository;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Context;
using DataAccess.Concrete.EntityFramework.Repository;
using DataAccess.Concrete.NHibarnate.Helpers;
using DataAccess.Concrete.NHibarnate.Repository;
using Microsoft.EntityFrameworkCore;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            // ProxyGenerationOptions ve AspectInterceptorSelector tanımlanıyor
            var proxyGenerator = new ProxyGenerator();
            var proxyOptions = new ProxyGenerationOptions() 
            { 
                Selector = new AspectInterceptorSelector() 
            };

            // Interceptor oluşturma fonksiyonu
            object CreateProxy(Type type, Func<object> instanceFactory)
            {
                var instance = instanceFactory();
                return proxyGenerator.CreateInterfaceProxyWithTarget(type, instance, proxyOptions);
            }

            // Örnek olarak bir interceptor başlatma
            var methodInterception = new MethodInterception();
            methodInterception.RuntimeInitialize();

            // Business için Dependency Injection
            Bind<IProductService>().ToMethod(ctx =>
                (IProductService)CreateProxy(typeof(IProductService), () => new ProductManager(ctx.Kernel.Get<IProductDal>())))
                .InSingletonScope();
            // Buraya diğer servisler gelecek

            // Data Access için Dependency Injection
            Bind<IProductDal>().To<EfProductDal>();
            Bind<ICategoryDal>().To<EfCategoryDal>();
            Bind<ICustomerDal>().To<EfCustomerDal>();
            Bind<IUserDal>().To<EfUserDal>();
            Bind<IOrderDal>().To<EfOrderDal>();
            Bind<IOrderDetailDal>().To<EfOrderDetailDal>();


            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            Bind<DbContext>().To<StockContext>();
            Bind<NHibernateHelper>().To<SqlServerHelper>();
        }
    }
}
