using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WebStore.WPF.Infrastructure.Commands.Base
{
    internal abstract class CommandAsync : ICommand
    {
        private bool _Executing;
        private event EventHandler _CanExecuteChanged;

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                _CanExecuteChanged += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
                _CanExecuteChanged -= value;
            }
        }

        protected virtual void OnCanExecuteChanged(EventArgs e = null) => _CanExecuteChanged?.Invoke(this, e ?? EventArgs.Empty);

        bool ICommand.CanExecute(object parameter) => !_Executing && CanExecute(parameter);

        async void ICommand.Execute(object parameter)
        {
            if (!CanExecute(parameter)) return;
            _Executing = true;
            try
            {
                OnCanExecuteChanged();
                await ExecuteAsync(parameter);
            }
            finally
            {
                _Executing = false;
            }
            OnCanExecuteChanged();
        }

        protected virtual bool CanExecute(object parameter) => true;

        protected abstract Task ExecuteAsync(object parameter);
    }
}