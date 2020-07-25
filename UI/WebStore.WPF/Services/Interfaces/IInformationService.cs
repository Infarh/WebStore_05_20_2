using System;
using System.Threading.Tasks;

namespace WebStore.WPF.Services.Interfaces
{
    interface IInformationService
    {
        string Address { get; }

        bool Connected { get; }

        Task ConnectTo(string address);

        Task Disconnect();

        Task Invoke(string Method, object arg);
        Task Invoke(string Method, object arg1, object arg2);
        Task Invoke(string Method, object arg1, object arg2, object arg3);

        IDisposable Listen(string EventId, Action action);
        IDisposable Listen<T>(string EventId, Action<T> action);
        IDisposable Listen<T1, T2>(string EventId, Action<T1, T2> action);
        IDisposable Listen<T1, T2, T3>(string EventId, Action<T1, T2, T3> action);
    }
}
