using Microsoft.Extensions.DependencyInjection;

namespace WebStore.WPF.ViewModels
{
    internal static class ViewModelRegistrator
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) => services
           .AddSingleton<MainWindowViewModel>()
        ;
    }
}
