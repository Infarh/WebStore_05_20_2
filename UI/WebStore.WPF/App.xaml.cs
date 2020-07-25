using System;
using System.Linq;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebStore.WPF.Services;
using WebStore.WPF.ViewModels;

namespace WebStore.WPF
{
    public partial class App
    {
        public static Window ActiveWindow => Current.Windows.Cast<Window>().FirstOrDefault(window => window.IsActive);

        public static Window FocusedWindow => Current.Windows.Cast<Window>().FirstOrDefault(window => window.IsFocused);

        private static IHost __Host;

        public static IHost Host => __Host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static IServiceProvider Services => Host.Services;

        public static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
           .Configure<AppSettings>(host.Configuration)
           .AddViewModels()
           .AddServices()
        ;

        protected override async void OnStartup(StartupEventArgs e)
        {
            var host = Host;
            base.OnStartup(e);

            await host.StartAsync();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            var host = Host;
            base.OnExit(e); 

            await host.StopAsync();
            __Host = null;
            host.Dispose();
        }
    }
}
