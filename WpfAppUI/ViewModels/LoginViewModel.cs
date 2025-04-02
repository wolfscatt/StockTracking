using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using WpfAppUI.Models;
using WpfAppUI.Services;
using WpfAppUI.Services.Interfaces;
using WpfAppUI.Commands;

namespace WpfAppUI.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public Action<string, Action> PopupRequest { get; set; }

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
            if (user != null)
            {
                _userService.Login(user);

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
