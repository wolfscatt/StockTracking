using Autofac;
using Business.Abstract;
using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppUI.DependencyResolvers;
using WpfAppUI.Services;
using WpfAppUI.Services.Interfaces;

namespace WpfAppUI.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly IProductServiceFrontEnd _productService;
        private int _totalProductCount;
        private int _criticalStockCount;
        private int _totalUnitsInStock;
        private SeriesCollection _pieSeries;
        public int TotalProductCount 
        { 
            get => _totalProductCount;
            set
            {
                _totalProductCount = value;
                OnPropertyChanged(nameof(TotalProductCount));
            } 
        }
        public int CriticalStockCount
        {
            get => _criticalStockCount;
            set
            {
                _criticalStockCount = value;
                OnPropertyChanged(nameof(CriticalStockCount));
            }
        }
        public int TotalUnitsInStock
        {
            get => _totalUnitsInStock;
            set
            {
                _totalUnitsInStock = value;
                OnPropertyChanged(nameof(TotalUnitsInStock));
            }
        }
        public SeriesCollection PieSeries
        {
            get => _pieSeries;
            set
            {
                _pieSeries = value;
                OnPropertyChanged(nameof(PieSeries));
            }
        }

        public HomeViewModel()
        {
            _productService = new ProductService();
            LoadData();
        }

        private async void LoadData()
        {
            var products = GlobalDataService.Products;

            TotalProductCount = products.Count;
            CriticalStockCount = GlobalDataService.CriticalStockCount;
            TotalUnitsInStock = GlobalDataService.TotalStockAmount;

            PieSeries = new SeriesCollection();

            var grouped = products
                .GroupBy(p => p.Category?.CategoryName ?? "Belirsiz")
                .ToList();

            foreach (var group in grouped)
            {
                PieSeries.Add(new PieSeries
                {
                    Title = group.Key,
                    Values = new ChartValues<int> { group.Sum(p => p.UnitsInStock) },
                    DataLabels = true
                });
            }

        }
    }
}
