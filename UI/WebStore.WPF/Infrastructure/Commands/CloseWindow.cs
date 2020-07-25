using System.Windows;
using WebStore.WPF.Infrastructure.Commands.Base;

namespace WebStore.WPF.Infrastructure.Commands
{
    internal class CloseWindow : Command
    {
        protected override void Execute(object parameter) => (parameter as Window ?? App.FocusedWindow ?? App.ActiveWindow)?.Close();
    }
}
