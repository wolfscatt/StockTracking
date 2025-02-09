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
using System.Windows.Shapes;
using WpfAppUI.ViewModels;

namespace WpfAppUI.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private Action _onPopupClose;
        public LoginWindow()
        {
            InitializeComponent();
            var viewModel = new LoginViewModel();
            viewModel.PopupRequest = ShowPopup;
            DataContext = viewModel;
        }
        private void ShowPopup(string message, Action onPopupClose)
        {
            NotificationPopup.IsOpen = true;
            ((LoginViewModel)DataContext).PopupMessage = message;
            _onPopupClose = onPopupClose;
        }

        private void ClosePopup(object sender, RoutedEventArgs e)
        {
            NotificationPopup.IsOpen = false;
            _onPopupClose?.Invoke();
        }

        private void NotificationPopup_Opened(object sender, EventArgs e)
        {
            var animation = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(300));
            PopupScaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, animation);
            PopupScaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, animation);
        }

        private void NotificationPopup_Closed(object sender, EventArgs e)
        {
            var animation = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(200));
            PopupScaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, animation);
            PopupScaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, animation);
        }
    }
}
