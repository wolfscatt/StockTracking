using Entities.Concrete;

namespace WpfAppUI.Services.Interfaces
{
    public interface IOrderServiceFrontEnd
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order?> GetOrderByIdAsync(int orderId);
        Task<Order> CreateOrderAsync(Order order);
        Task<Order> UpdateOrderAsync(Order order);
        Task<bool> DeleteOrderAsync(int orderId);
    }
}