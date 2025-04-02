using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfAppUI.ViewModels;

namespace WpfAppUI.Views
{
    public partial class ProductsView : UserControl
    {
        public ProductsView()
        {
            InitializeComponent();
            DataContext = new ProductsViewModel();
        }

    }
} 