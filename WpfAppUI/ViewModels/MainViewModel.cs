using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfAppUI.Models;
using WpfAppUI.State.Navigators;
using WpfAppUI.Views;

namespace WpfAppUI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<PageItem> Pages { get; set; }
        private UserControl _currentView;

        public UserControl CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }
        public MainViewModel()
        {
            // Sayfa koleksiyonunu doldur
            Pages = new ObservableCollection<PageItem>
            {
                new PageItem { Title = "Anasayfa", Icon = "Home", ViewName = "HomeView" },
                new PageItem { Title = "Ürünler", Icon = "Cart", ViewName = "ProductsView" },
                new PageItem { Title = "Siparişler", Icon = "Archive", ViewName = "OrdersView" },
                new PageItem { Title = "Ayarlar", Icon = "Cog", ViewName = "SettingsView" }
                // Yeni bir Navigation ekleneceği zaman buraya bir pageitem eklenir
            };

            // İlk görünüm HomeView
            CurrentView = new HomeView();
        }

        public void ChangeView(string viewName)
        {
            // ViewName'e göre UserControl oluştur ve CurrentView'a ata
            switch (viewName)
            {
                case "HomeView":
                    CurrentView = new HomeView();
                    break;
                case "ProductsView":
                    CurrentView = new ProductsView();
                    break;
                case "OrdersView":
                    CurrentView = new OrdersView();
                    break;
                case "SettingsView":
                    CurrentView = new SettingsView();
                    break;
            }
        }
    }
}
