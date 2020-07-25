using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace WebStore.WPF.ViewModels
{
    internal class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel => App.Services.GetRequiredService<MainWindowViewModel>();
    }
}
