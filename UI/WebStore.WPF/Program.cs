using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace WebStore.WPF
{
    public static class Program
    {
        [STAThread]
        public static void Main(string[] Args)
        {
            var app = new App();
            app.InitializeComponent();
            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] Args) =>
            Host.CreateDefaultBuilder(Args)
               .ConfigureAppConfiguration(configuration => configuration
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true))
               .ConfigureServices(App.ConfigureServices)
        ;
    }
}
