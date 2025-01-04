using Business.Abstract;
using Business.Concrete.ValidationRules.FluentValidation;
using Core.Aspects.CastleDynamicProxy.CacheAspects;
using Core.Aspects.CastleDynamicProxy.TransactionAspects;
using Core.Aspects.CastleDynamicProxy.ValidationAspects;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager()
        {
            
        }

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public virtual List<Product> GetAll()
        {
            return _productDal.GetAll();
        }
        public Product GetById(int Id)
        {
            return _productDal.Get(p => p.ProductId == Id);
        }

        [FluentValidationAspect(typeof(ProductValidator), Priority = 1)]
        [CacheRemoveAspect(typeof(MemoryCacheManager), Priority = 2)]
        public virtual Product Add(Product product)
        {
            //ValidatorTool.FluentValidate(new ProductValidator(), product);
            return _productDal.Add(product);
        }

        [FluentValidationAspect(typeof(ProductValidator), Priority = 1)]
        [CacheRemoveAspect(typeof(MemoryCacheManager), Priority = 2)]
        public virtual Product Update(Product product)
        {
            //ValidatorTool.FluentValidate(new ProductValidator(), product);
            return _productDal.Update(product);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager), Priority = 2)]
        public virtual void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        [TransactionScopeAspect]
        public virtual void TransactionalOperation(Product product1, Product product2)
        {
            Add(product1);
            Update(product2);
        }
    }
}
