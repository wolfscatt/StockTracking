using Autofac;
using Business.DependencyResolvers.Autofac;
using System.Configuration;
using System.Data;
using System.Windows;
using WpfAppUI.ViewModels;

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
            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = new MainViewModel();
            mainWindow.Show();


            var builder = new ContainerBuilder();
            builder.RegisterModule(new AutofacBusinessModule());
            Container = builder.Build();



            base.OnStartup(e);
        }
    }

}
