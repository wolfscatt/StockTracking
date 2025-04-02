using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfAppUI.Views
{
    /// <summary>
    /// Interaction logic for ProductDetailWindow.xaml
    /// </summary>
    public partial class ProductDetailWindow : Window
    {
        public Product Product { get; set; }

        public ProductDetailWindow(Product product)
        {
            InitializeComponent();
            Product = product;
            DataContext = this;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
