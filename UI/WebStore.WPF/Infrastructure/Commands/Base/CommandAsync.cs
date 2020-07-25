using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WebStore.WPF.Infrastructure.Commands.Base
{
    internal abstract class CommandAsync : ICommand
    {
        private bool _Executing;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        bool ICommand.CanExecute(object parameter) => !_Executing && CanExecute(parameter);

        async void ICommand.Execute(object parameter)
        {
            if (!CanExecute(parameter)) return;
            _Executing = true;
            try
            {
                CommandManager.InvalidateRequerySuggested();
                await ExecuteAsync(parameter);
            }
            finally
            {
                _Executing = false;
            }
            CommandManager.InvalidateRequerySuggested();
        }

        protected virtual bool CanExecute(object parameter) => true;

        protected abstract Task ExecuteAsync(object parameter);
    }
}