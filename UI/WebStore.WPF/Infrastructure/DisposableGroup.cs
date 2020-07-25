using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.WPF.Infrastructure
{ 
    internal sealed class DisposableGroup : List<IDisposable>, IDisposable
    {
        public void Dispose()
        {
            if (Count == 0) return;
            var errors = new List<Exception>(Count);
            foreach (var disposable in this)
                try
                {
                    disposable.Dispose();
                }
                catch (Exception error)
                {
                    errors.Add(error);
                }

            if(errors.Count > 0)
                throw new AggregateException("Ошибка при освобождении ресурсов", errors);
        }
    }
}
