using Lamar;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace wpfioclamar
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private Container _container;

        public App()
        {
            var services = new ServiceRegistry();

            ConfigureServices(services);

            _container = new Container(services);
        }

        private void ConfigureServices(ServiceRegistry services)
        {
            services.For<ITextService>().Use(new TextService("Hello WPF .NET Core 3.0!"));
        }

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _container.GetInstance<MainWindow>();
            mainWindow.Show();
        }
    }
}