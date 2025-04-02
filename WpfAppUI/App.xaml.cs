using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using MaterialDesignThemes.Wpf;
using WpfAppUI.Services;
using WpfAppUI.Services.Interfaces;
using WpfAppUI.ViewModels;
using WpfAppUI.Views;
using Autofac;
using Business.DependencyResolvers.Autofac;
using WpfAppUI.DependencyResolvers;
using Entities.Concrete;
using System.Collections.ObjectModel;

namespace WpfAppUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        //private void ConfigureServices(IServiceCollection services)
        //{
        //    // HTTP Client
        //    services.AddHttpClient<IProductService, ProductService>(client =>
        //    {
        //        client.BaseAddress = new Uri(ApiBaseUrl);
        //    });


        //    // ViewModels
        //    services.AddTransient<MainWindowViewModel>();
        //    services.AddTransient<LoginViewModel>();
        //    services.AddTransient<DashboardViewModel>(provider => new DashboardViewModel(
        //        Locator.Current.GetService<IScreen>(),
        //        provider.GetRequiredService<IProductService>(),
        //        provider.GetRequiredService<ISnackbarMessageQueue>()
        //    ));
        //    services.AddTransient<ProductsViewModel>();
        //    services.AddTransient<SettingsViewModel>();

        //    // Views
        //    services.AddTransient<MainWindow>();
        //    services.AddTransient<LoginWindow>();
        //    services.AddTransient<DashboardView>();
        //    services.AddTransient<ProductsView>();
        //    services.AddTransient<SettingsView>();
        //}

        protected override void OnStartup(StartupEventArgs e)
        {

            IocContainer.Build();

            var loginWindow = new LoginWindow();
            loginWindow.Show();

            LoadInitialData();

            var settingsService = new SettingsService();
            var preferences = settingsService.LoadSettings();
            // Tema uygula
            var paletteHelper = new PaletteHelper();
            var theme = paletteHelper.GetTheme();
            theme.SetBaseTheme(preferences.IsDarkTheme ? BaseTheme.Dark : BaseTheme.Light);
            paletteHelper.SetTheme(theme);

            base.OnStartup(e);
        }

        private async void LoadInitialData()
        {
            Task.Run(async () =>
            {
                var productService = new ProductService();
                var categoryService = new CategoryService();

                var products = await productService.GetAllProductsAsync();
                var categories = await categoryService.GetAllCategoriesAsync();

                Application.Current.Dispatcher.Invoke(() =>
                {
                    GlobalDataService.Products = new ObservableCollection<Product>(products);
                    GlobalDataService.Categories = new ObservableCollection<Category>(categories);
                });
            });
        }
    }
}
