using Autofac;
using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppUI.DependencyResolvers;
using WpfAppUI.Services.Interfaces;

namespace WpfAppUI.Services
{
    public class OrderService : IOrderServiceFrontEnd
    {
        private readonly IOrderService _orderService;
        public OrderService()
        {
            _orderService = IocContainer.Container.Resolve<IOrderService>();
        }
        public async Task<Order> CreateOrderAsync(Order order)
        {
            return await Task.Run(() =>
            {
                var result = _orderService.Add(order);
                if (result.Success)
                {
                    return order;
                }
                return new Order();
            });
        }
        public async Task<Order> UpdateOrderAsync(Order order)
        {
            return await Task.Run(() =>
            {
                var result = _orderService.Update(order);
                if (result.Success)
                {
                    return order;
                }
                return new Order();
            });
        }

        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            return await Task.Run(() =>
            {
                var orderToDelete = _orderService.GetById(orderId).Data;
                if (orderToDelete != null)
                {
                    var result = _orderService.Delete(orderToDelete);
                    return result.Success;
                }
                return false;
            });
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await Task.Run(() =>
            {
                var result = _orderService.GetList();
                if (result.Success)
                {
                    return result.Data;
                }

                return new List<Order>();
            });
        }

        public async Task<Order?> GetOrderByIdAsync(int orderId)
        {
            return await Task.Run(() =>
            {
                var result = _orderService.GetById(orderId);
                if (result.Success)
                {
                    return result.Data;
                }
                return null;
            });
        }

    }
}
