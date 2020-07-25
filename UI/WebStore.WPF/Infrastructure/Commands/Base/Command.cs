﻿using System;
using System.Windows.Input;

namespace WebStore.WPF.Infrastructure.Commands.Base
{
    internal abstract class Command : ICommand
    {
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

        bool ICommand.CanExecute(object parameter) => CanExecute(parameter);

        void ICommand.Execute(object parameter)
        {
            if (CanExecute(parameter))
                Execute(parameter);
        }

        protected virtual bool CanExecute(object parameter) => true;

        protected abstract void Execute(object parameter);
    }
}
