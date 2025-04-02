using Entities.Concrete;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfAppUI.Commands;
using WpfAppUI.Models;
using WpfAppUI.Services;
using WpfAppUI.Views;

namespace WpfAppUI.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private readonly PaletteHelper _paletteHelper = new PaletteHelper();
        private readonly SettingsService _settingsService = new SettingsService();
        private readonly UserService _userService;
        private UserPreferences _preferences;

        public bool IsDarkTheme
        {
            get => _preferences.IsDarkTheme;
            set
            {
                _preferences.IsDarkTheme = value;
                OnPropertyChanged(nameof(IsDarkTheme));
                ApplyTheme(value);
                SavePreferences();
            }
        }
        public ICommand LogoutCommand { get; }

        public string FullName => UserSession.Instance.CurrentUser?.FullName;
        public string Email => UserSession.Instance.CurrentUser?.Email;
        public string Username => UserSession.Instance.CurrentUser?.Username;


        public SettingsViewModel()
        {
            _preferences = _settingsService.LoadSettings();
            ApplyTheme(_preferences.IsDarkTheme);
            _userService = new UserService(); // Bu, kullanıcı verisini kaydeden servis
            LogoutCommand = new RelayCommand(ExecuteLogout);
        }
        private async void ExecuteLogout(object parameter)
        {
            bool result = await DialogService.ShowConfirmation("Oturumu kapatmak istediğinizden emin misiniz?", "LogoutDialogHost");


            if (result)
            {
                // Animasyon gibi biraz gecikme efekti
                await Task.Delay(300); // küçük bir geçiş efekti

                _userService.Logout();

                var loginWindow = new LoginWindow();
                Application.Current.MainWindow = loginWindow;
                loginWindow.Show();

                foreach (Window window in Application.Current.Windows)
                {
                    if (window is MainWindow)
                    {
                        window.Close();
                        break;
                    }
                }
            }
        }


        private void ApplyTheme(bool isDark)
        {
            var theme = _paletteHelper.GetTheme();
            theme.SetBaseTheme(isDark ? BaseTheme.Dark : BaseTheme.Light);
            _paletteHelper.SetTheme(theme);
        }
        private void SavePreferences()
        {
            _settingsService.SaveSettings(_preferences);
        }
    }
}
