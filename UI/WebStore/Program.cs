using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;

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
                })
               .UseSerilog((host, log) => log.ReadFrom.Configuration(host.Configuration)
                   .MinimumLevel.Debug()
                   .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                   .Enrich.FromLogContext()
                   .WriteTo.Console(
                        outputTemplate: "[{Timestamp:HH:mm:ss.fff} {Level:u3}]{SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}")
                   .WriteTo.RollingFile($@".\Logs\WebStore[{DateTime.Now:yyyy-MM-ddTHH-mm-ss}].log")
                   .WriteTo.File(new JsonFormatter(",", true), $@".\Logs\WebStore[{DateTime.Now:yyyy-MM-ddTHH-mm-ss}].log.json")
                   .WriteTo.Seq("http://localhost:5341/"));
    }
}
