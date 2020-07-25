using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using WebStore.WPF.Infrastructure;
using WebStore.WPF.Services.Interfaces;

namespace WebStore.WPF.Services
{
    class SignalRInformationService : IInformationService
    {
        private HubConnection _Connection;
        private string _Address;
        private DisposableGroup _ConnectionsSubscribers;

        public string Address => _Address;

        public bool Connected => _Connection?.State == HubConnectionState.Connected;

        public async Task ConnectTo(string address)
        {
            if (Connected)
                await Disconnect();

            _Address = address;
            _Connection = new HubConnectionBuilder()
               .WithUrl(address)
               .Build();
            await _Connection.StartAsync();
            _ConnectionsSubscribers = new DisposableGroup();
        }

        public async Task Disconnect()
        {
            if (!Connected) return;
            _ConnectionsSubscribers.Dispose();
            await _Connection.StopAsync();
            _Connection = null;
        }

        public async Task Invoke(string Method, object arg)
        {
            await _Connection.SendAsync(Method, arg);
        }

        public async Task Invoke(string Method, object arg1, object arg2)
        {
            await _Connection.SendAsync(Method, arg1, arg2);
        }

        public async Task Invoke(string Method, object arg1, object arg2, object arg3)
        {
            await _Connection.SendAsync(Method, arg1, arg2, arg3);
        }

        public IDisposable Listen(string EventId, Action action)
        {
            if(!Connected) throw new InvalidOperationException("Невозможно установить наблюдатель для неподключённого сервиса");
            var unsubscriber = _Connection.On(EventId, action);
            _ConnectionsSubscribers.Add(unsubscriber);
            return unsubscriber;
        }

        public IDisposable Listen<T>(string EventId, Action<T> action)
        {
            if (!Connected) throw new InvalidOperationException("Невозможно установить наблюдатель для неподключённого сервиса");
            var unsubscriber = _Connection.On(EventId, action);
            _ConnectionsSubscribers.Add(unsubscriber);
            return unsubscriber;
        }

        public IDisposable Listen<T1, T2>(string EventId, Action<T1, T2> action)
        {
            if (!Connected) throw new InvalidOperationException("Невозможно установить наблюдатель для неподключённого сервиса");
            var unsubscriber = _Connection.On(EventId, action);
            _ConnectionsSubscribers.Add(unsubscriber);
            return unsubscriber;
        }

        public IDisposable Listen<T1, T2, T3>(string EventId, Action<T1, T2, T3> action)
        {
            if (!Connected) throw new InvalidOperationException("Невозможно установить наблюдатель для неподключённого сервиса");
            var unsubscriber = _Connection.On(EventId, action);
            _ConnectionsSubscribers.Add(unsubscriber);
            return unsubscriber;
        }
    }
}
