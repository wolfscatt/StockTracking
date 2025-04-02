using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppUI.Commands;
using WpfAppUI.Services;
using WpfAppUI.Services.Interfaces;

namespace WpfAppUI.ViewModels
{
    public class OrdersViewModel : ViewModelBase
    {
        private readonly IOrderServiceFrontEnd _orderService;

        private ObservableCollection<Order> _orders;
        public ObservableCollection<Order> Orders
        {
            get => _orders;
            set
            {
                _orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }
        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }


        public OrdersViewModel()
        {
            _orderService = new OrderService(); // Autofac ile çözülmüş olacak
            Orders = new ObservableCollection<Order>();

            LoadOrders();

        }

        private async Task LoadOrders()
        {
            IsLoading = true;

            var orders = await _orderService.GetAllOrdersAsync();
            Orders = new ObservableCollection<Order>(orders);

            IsLoading = false;
        }
    }
}
