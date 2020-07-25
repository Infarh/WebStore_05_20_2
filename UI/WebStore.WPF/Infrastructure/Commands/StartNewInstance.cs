using System.Diagnostics;
using WebStore.WPF.Infrastructure.Commands.Base;

namespace WebStore.WPF.Infrastructure.Commands
{
    internal class StartNewInstance : Command
    {
        protected override void Execute(object parameter) => Process.Start(System.IO.Path.ChangeExtension(System.Environment.CommandLine, ".exe"));
    }
}
