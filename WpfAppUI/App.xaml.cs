using Autofac;
using Business.DependencyResolvers.Autofac;
using MaterialDesignThemes.Wpf;
using System.Configuration;
using System.Data;
using System.Windows;
using WpfAppUI.Services;
using WpfAppUI.ViewModels;
using WpfAppUI.Views;

namespace WpfAppUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IContainer Container;
        protected override void OnStartup(StartupEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();


            var builder = new ContainerBuilder();
            builder.RegisterModule(new AutofacBusinessModule());
            Container = builder.Build();

            var settingsService = new SettingsService();
            var preferences = settingsService.LoadSettings();
            // Tema uygula
            var paletteHelper = new PaletteHelper();
            var theme = paletteHelper.GetTheme();
            theme.SetBaseTheme(preferences.IsDarkTheme ? BaseTheme.Dark : BaseTheme.Light);
            paletteHelper.SetTheme(theme);

            base.OnStartup(e);
        }
    }

}
