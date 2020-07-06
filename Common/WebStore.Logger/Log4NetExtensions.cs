using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Logging;

namespace WebStore.Logger
{
    public static class Log4NetExtensions
    {
        public static ILoggerFactory AddLog4Net(this ILoggerFactory Factory, string ConfigurationFile = "log4net.config")
        {
            if (!Path.IsPathRooted(ConfigurationFile))
            {
                var assembly = Assembly.GetEntryAssembly() ?? throw new InvalidOperationException("Не определена сборка с точкой входа в прлиожение");
                var dir = Path.GetDirectoryName(assembly.Location) ?? throw new InvalidOperationException("Не удалось определить путь к дирректории исполнительной сборки");
                ConfigurationFile = Path.Combine(dir, ConfigurationFile);
            }

            Factory.AddProvider(new Log4NetLoggerProvider(ConfigurationFile));

            return Factory;
        }
    }
}