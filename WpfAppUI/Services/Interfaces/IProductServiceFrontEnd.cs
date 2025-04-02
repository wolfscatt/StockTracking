using Entities.Concrete;
using WpfAppUI.Models;

namespace WpfAppUI.Services.Interfaces
{
    public interface IProductServiceFrontEnd
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<bool> AddProductAsync(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(int id);
        Task<List<Product>> SearchProductsAsync(string searchTerm);
        Task<int> GetCriticalStockCount(int threshold = 5);
        Task<int> GetTotalStockAmount();
    }
   
}