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

namespace WpfAppUI.ViewModels
{
    public class SettingsViewModel: BaseViewModel
    {
        private readonly PaletteHelper _paletteHelper = new PaletteHelper();
        private readonly SettingsService _settingsService = new SettingsService();
        private readonly UserService _userService;
        private UserPreferences _preferences;
        private bool _isModified;
        private User _currentUser;
        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                IsModified = true;
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }
        public bool IsModified
        {
            get => _isModified;
            set
            {
                _isModified = value;
                OnPropertyChanged(nameof(IsModified));
            }
        }

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
        public ICommand UpdateCommand { get; }

        private bool CanUpdate(object parameter) => IsModified;

        public SettingsViewModel()
        {
            _preferences = _settingsService.LoadSettings();
            ApplyTheme(_preferences.IsDarkTheme);
            _userService = new UserService(); // Bu, kullanıcı verisini kaydeden servis
            CurrentUser = UserSession.Instance.CurrentUser;
            UpdateCommand = new RelayCommand(UpdateUser, CanUpdate);
        }
        private void UpdateUser(object parameter)
        {
            // Güncelleme işlemi (örneğin UserService üzerinden kaydetme)
            _userService.UpdateUser(CurrentUser);
            IsModified = false; // Güncelleme sonrası butonu devre dışı bırak
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
