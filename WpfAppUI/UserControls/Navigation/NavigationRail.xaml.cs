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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppUI.Models;
using WpfAppUI.ViewModels;
using WpfAppUI.Views;

namespace WpfAppUI.UserControls.Navigation
{
    /// <summary>
    /// Interaction logic for NavigationRail.xaml
    /// </summary>
    public partial class NavigationRail : UserControl
    {
        public NavigationRail()
        {
            InitializeComponent();
            Loaded += NavigationRail_Loaded;  // Loaded olayını bağla
        }
        private void NavigationRail_Loaded(object sender, RoutedEventArgs e)
        {
            AnimateWidth(240);  // Başlangıçta genişlik tam açık olsun
            ToggleButton.IsChecked = true;  // ToggleButton başlangıçta "Checked" olarak ayarlanır
        }
        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            AnimateWidth(240);  // Genişletilmiş durum
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            AnimateWidth(80);  // Daraltılmış durum
        }
        private void AnimateWidth(double targetWidth)
        {
            DoubleAnimation widthAnimation = new DoubleAnimation
            {
                To = targetWidth,
                Duration = TimeSpan.FromMilliseconds(300),  // Animasyon süresi 300ms
                EasingFunction = new QuadraticEase()  // Daha yumuşak bir geçiş için easing function
            };

            NavGrid.BeginAnimation(WidthProperty, widthAnimation);
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext is MainViewModel viewModel && e.AddedItems.Count > 0)
            {
                var selectedItem = e.AddedItems[0] as PageItem;
                if (selectedItem != null)
                {
                    viewModel.ChangeView(selectedItem.ViewName);
                }
            }
        }
    }
}
