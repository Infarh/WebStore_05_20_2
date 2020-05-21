using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace WebStore
{
    public class Program
    {
        public static void Main(string[] args) => 
            CreateHostBuilder(args)
               .Build()
               .Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
               .ConfigureAppConfiguration(opt => opt.AddIniFile("config.ini", optional: true, reloadOnChange: true))
                .ConfigureWebHostDefaults(host =>
                {
                    host.UseStartup<Startup>();
                });
    }
}
