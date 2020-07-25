using System;
using System.Threading.Tasks;

namespace WebStore.WPF.Services.Interfaces
{
    interface IInformationService
    {
        string Address { get; }

        bool Connected { get; }

        Task ConnectTo(string address, string hub);

        Task Disconnect();

        Task Invoke(string Method, params object[] args);
        Task<T> Invoke<T>(string Method, params object[] args);
        Task Invoke<TProgress>(string Method, Action<TProgress> Progress, params object[] args);
        Task<TResult> Invoke<TProgress, TResult>(string Method, Action<TProgress> Progress, params object[] args);

        IDisposable Listen(string EventId, Action action);
        IDisposable Listen<T>(string EventId, Action<T> action);
        IDisposable Listen<T1, T2>(string EventId, Action<T1, T2> action);
        IDisposable Listen<T1, T2, T3>(string EventId, Action<T1, T2, T3> action);
    }
}
