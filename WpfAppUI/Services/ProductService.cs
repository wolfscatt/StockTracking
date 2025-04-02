using Autofac;
using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WpfAppUI.DependencyResolvers;
using WpfAppUI.Models;
using WpfAppUI.Services.Interfaces;

namespace WpfAppUI.Services
{
    public class ProductService : IProductServiceFrontEnd
    {
        private readonly IProductService _productService;

        public ProductService()
        {
            _productService = IocContainer.Container.Resolve<IProductService>();
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            return await Task.Run(() =>
            {
                var result = _productService.Add(product);
                return result.Success;
            });
        }
        public async Task<bool> UpdateProductAsync(Product product)
        {
            return await Task.Run(() =>
            {
                var result = _productService.Update(product);
                return result.Success;
            });
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            return await Task.Run(() =>
            {
                var productToDelete = _productService.GetById(id).Data;
                if (productToDelete != null)
                {
                    var result = _productService.Delete(productToDelete);
                    return result.Success;
                }
                return false;
            });
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await Task.Run(() =>
            {
                var result = _productService.GetList();
                if (result.Success)
                {
                    return result.Data;
                }

                return new List<Product>();
            });
        }

        public async Task<int> GetCriticalStockCount(int threshold = 5)
        {
            return await Task.Run(() =>
            {
                var result = _productService.GetList();
                return result.Data.Count(p => p.UnitsInStock < threshold);
            });
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await Task.Run(() =>
            {
                var result = _productService.GetById(id);
                if (result.Success)
                {
                    return result.Data;

                }

                return null;
            });
        }

        public async Task<int> GetTotalStockAmount()
        {
            return await Task.Run(() =>
            {
                var result = _productService.GetList();
                return result.Data.Sum(p => p.UnitsInStock);
            });
        }

        public async Task<List<Product>> SearchProductsAsync(string searchTerm)
        {
            return await Task.Run(() =>
            {
                var result = _productService.GetList();
                return result.Data
                    .Where(p => !string.IsNullOrEmpty(p.ProductName) && p.ProductName.ToLower().Contains(searchTerm.ToLower()))
                    .ToList();
            });
        }


    }

}
