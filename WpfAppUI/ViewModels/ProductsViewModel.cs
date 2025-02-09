using Autofac;
using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppUI.ViewModels
{
    public class ProductsViewModel :BaseViewModel
    {
        /*
        public event PropertyChangedEventHandler? PropertyChanged;

        IProductService productService = App.Container.Resolve<IProductService>();
        private Product _selectedProduct;

        public ObservableCollection<Product> Products { get; set; }
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged();
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ProductsViewModel()
        {
            Products = new ObservableCollection<Product>(productService.GetList().Data);
        }

        public void AddProduct()
        {
            productService.Add(SelectedProduct);
            Products.Add(SelectedProduct);
        }

        public void UpdateProduct()
        {
            productService.Update(SelectedProduct);
        }

        public void DeleteProduct()
        {
            productService.Delete(SelectedProduct);
            Products.Remove(SelectedProduct);
        }
        */
    }
}
