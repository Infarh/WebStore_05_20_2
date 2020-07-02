using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;

namespace WebStore.ServiceHosting
{
    public class Program
    {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                //.ConfigureLogging((host, log) => log
                //   .AddConfiguration(host.Configuration)
                //   .ClearProviders()
                //   .AddConsole())
                //.ConfigureLogging((host, log) =>
                //{
                //    log.ClearProviders();
                //    //log.AddProvider(new ConsoleLoggerProvider())
                //    log.AddConsole(opt => opt.IncludeScopes = true);
                //    log.AddEventLog(opt => opt.LogName = "WebStore.log");
                //    log.AddFilter((str, level) =>
                //    {
                //        if (str.Contains("test", StringComparison.OrdinalIgnoreCase))
                //            return level >= LogLevel.Debug;
                //        return true;
                //    });
                //    log.AddFilter<ConsoleLoggerProvider>("Microsoft", LogLevel.Information);
                //})
                .ConfigureWebHostDefaults(host => host
                   .UseStartup<Startup>()
                );
    }
}
