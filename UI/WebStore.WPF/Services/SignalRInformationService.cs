using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using WebStore.WPF.Infrastructure;
using WebStore.WPF.Services.Interfaces;

namespace WebStore.WPF.Services
{
    class SignalRInformationService : IInformationService
    {
        private IHubProxy _Hub;
        private HubConnection _Connection;
        private string _HubName;
        private DisposableGroup _ConnectionsSubscribers;

        public string Address => _Connection is null ? null : $"{_Connection?.Url}//{_HubName}";

        public bool Connected => _Connection?.State == ConnectionState.Connected;

        public async Task ConnectTo(string address, string hub)
        {
            if (Connected)
                await Disconnect();

            _Connection = new HubConnection(address);
            await _Connection.Start();
            _ConnectionsSubscribers = new DisposableGroup();
            _Hub = _Connection.CreateHubProxy(hub);
            _HubName = hub;
        }

        public Task Disconnect()
        {
            if (!Connected) return Task.CompletedTask;
            var connection = _Connection;
            _ConnectionsSubscribers.Dispose();
            connection.Stop();
            _Connection = null;
            _Hub = null;
            _HubName = null;
            connection.Dispose();
            return Task.CompletedTask;
        }

        public async Task Invoke(string Method, params object[] args)
        {
            await _Hub.Invoke(Method, args);
        }

        public async Task<T> Invoke<T>(string Method, params object[] args)
        {
            return await _Hub.Invoke<T>(Method, args);
        }

        public async Task Invoke<TProgress>(string Method, Action<TProgress> Progress, params object[] args)
        {
            await _Hub.Invoke(Method, Progress, args);
        }

        public async Task<TResult> Invoke<TProgress, TResult>(string Method, Action<TProgress> Progress, params object[] args)
        {
            return await _Hub.Invoke<TResult, TProgress>(Method, Progress, args);
        }

        public IDisposable Listen(string EventId, Action action)
        {
            if(!Connected) throw new InvalidOperationException("Невозможно установить наблюдатель для неподключённого сервиса");
            var unsubscriber = _Hub.On(EventId, action);
            _ConnectionsSubscribers.Add(unsubscriber);
            return unsubscriber;
        }

        public IDisposable Listen<T>(string EventId, Action<T> action)
        {
            if (!Connected) throw new InvalidOperationException("Невозможно установить наблюдатель для неподключённого сервиса");
            var unsubscriber = _Hub.On(EventId, action);
            _ConnectionsSubscribers.Add(unsubscriber);
            return unsubscriber;
        }

        public IDisposable Listen<T1, T2>(string EventId, Action<T1, T2> action)
        {
            if (!Connected) throw new InvalidOperationException("Невозможно установить наблюдатель для неподключённого сервиса");
            var unsubscriber = _Hub.On(EventId, action);
            _ConnectionsSubscribers.Add(unsubscriber);
            return unsubscriber;
        }

        public IDisposable Listen<T1, T2, T3>(string EventId, Action<T1, T2, T3> action)
        {
            if (!Connected) throw new InvalidOperationException("Невозможно установить наблюдатель для неподключённого сервиса");
            var unsubscriber = _Hub.On(EventId, action);
            _ConnectionsSubscribers.Add(unsubscriber);
            return unsubscriber;
        }
    }
}
