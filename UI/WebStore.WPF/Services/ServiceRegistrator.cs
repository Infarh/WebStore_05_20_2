using Microsoft.Extensions.DependencyInjection;
using WebStore.WPF.Services.Interfaces;

namespace WebStore.WPF.Services
{
    internal static class ServiceRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
           .AddSingleton<IInformationService, SignalRInformationService>()
        ;
    }
}
