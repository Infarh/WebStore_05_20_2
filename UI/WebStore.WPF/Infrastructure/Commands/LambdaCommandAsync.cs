using System;
using System.Threading.Tasks;
using WebStore.WPF.Infrastructure.Commands.Base;

namespace WebStore.WPF.Infrastructure.Commands
{
    internal class LambdaCommandAsync : CommandAsync
    {
        private readonly ActionAsync<object> _Execute;
        private readonly Func<object, bool> _CanExecute;

        public LambdaCommandAsync(ActionAsync Execute, Func<bool> CanExecute = null)
            : this(async p => await Execute(), CanExecute is null ? (Func<object, bool>)null : p => CanExecute())
        {

        }

        public LambdaCommandAsync(ActionAsync<object> Execute, Func<object, bool> CanExecute = null)
        {
            _Execute = Execute;
            _CanExecute = CanExecute;
        }

        protected override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;

        protected override Task ExecuteAsync(object parameter) => _Execute(parameter);
    }
}