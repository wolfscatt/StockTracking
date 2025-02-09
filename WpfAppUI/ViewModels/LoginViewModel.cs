using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using WpfAppUI.Commands;
using WpfAppUI.Services;
using MaterialDesignThemes.Wpf;
using System.Windows.Controls;
using WpfAppUI.UserControls;
using WpfAppUI.Views;

namespace WpfAppUI.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Action<string,Action> PopupRequest { get; set; }

        private readonly UserService _userService;
        private string _username;
        private string _password;
        private string _errorMessage;

        private string _popupMessage;
        public string PopupMessage
        {
            get => _popupMessage;
            set
            {
                _popupMessage = value;
                OnPropertyChanged(nameof(PopupMessage));
            }
        }
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public ICommand LoginCommand { get; }
        public LoginViewModel()
        {
            _userService = new UserService();
            LoginCommand = new RelayCommand(Login, CanLogin);
        }
        private bool CanLogin(object parameter) => !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        private void Login(object parameter)
        {
            var user = _userService.Authenticate(Username, Password);
            // Simulate login logic; replace this with actual service call
            if (user != null)
            {
                // Kullanıcı bilgilerini UserSession'a kaydet
                UserSession.Instance.CurrentUser = user;

                PopupRequest?.Invoke($"Hoşgeldin, {user.FullName}!", () =>
                {
                    // MainWindow aç
                    var mainWindow = new MainWindow();
                    Application.Current.MainWindow = mainWindow;
                    mainWindow.Show();

                    // LoginWindow'u kapat
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window is Views.LoginWindow)
                        {
                            window.Close();
                            break;
                        }
                    }
                });
            }
            else
            {
                PopupRequest?.Invoke("Kullanıcı adı veya parola hatalı.", null);
            }
        }
    }
}
