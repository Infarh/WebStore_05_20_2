using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Extensions.Options;
using WebStore.WPF.Infrastructure.Commands;
using WebStore.WPF.Models;
using WebStore.WPF.Services.Interfaces;
using WebStore.WPF.ViewModels.Base;

namespace WebStore.WPF.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private readonly IInformationService _InformationService;

        #region Свойства

        public ObservableCollection<UserMessage> Messages { get; } = new ObservableCollection<UserMessage>();

        #region Title : string - Заголовок окна

        /// <summary>Заголовок окна</summary>
        private string _Title = "Тестовый клиент";

        /// <summary>Заголовок окна</summary>
        public string Title { get => _Title; set => Set(ref _Title, value); }

        #endregion

        #region Status : string - Статус

        /// <summary>Статус</summary>
        private string _Status = "Готов";

        /// <summary>Статус</summary>
        public string Status { get => _Status; private set => Set(ref _Status, value); }

        #endregion

        #region Address : string - Адрес сервиса

        /// <summary>Адрес сервиса</summary>
        private string _Address = "http://localhost:5000/information";

        /// <summary>Адрес сервиса</summary>
        public string Address { get => _Address; set => Set(ref _Address, value); }

        #endregion

        #region HubName : string - Имя хаба

        /// <summary>Имя хаба</summary>
        private string _HubName;

        /// <summary>Имя хаба</summary>
        public string HubName { get => _HubName; set => Set(ref _HubName, value); }

        #endregion

        #region UserName : string - Имя пользователя

        /// <summary>Имя пользователя</summary>
        private string _UserName = "TestUser";

        /// <summary>Имя пользователя</summary>
        public string UserName { get => _UserName; set => Set(ref _UserName, value); }

        #endregion

        #region Message : string - Сообщение

        /// <summary>Сообщение</summary>
        private string _Message;

        /// <summary>Сообщение</summary>
        public string Message { get => _Message; set => Set(ref _Message, value); }

        #endregion

        #endregion

        #region Команды

        #region Command ConnectCommand - Подключиться к сервису

        /// <summary>Подключиться к сервису</summary>
        private ICommand _ConnectCommand;

        /// <summary>Подключиться к сервису</summary>
        public ICommand ConnectCommand => _ConnectCommand
            ??= new LambdaCommandAsync(OnConnectCommandExecuted, CanConnectCommandExecute);

        /// <summary>Проверка возможности выполнения - Подключиться к сервису</summary>
        private bool CanConnectCommandExecute() => !_InformationService.Connected;

        /// <summary>Логика выполнения - Подключиться к сервису</summary>
        private async Task OnConnectCommandExecuted()
        {
         
            await _InformationService.ConnectTo(Address, HubName);
            _InformationService.Listen<string, string>("ChatMessage", OnChatMessageReceived);
        }

        #endregion

        #region Command DisconnectCommand - Отключиться от сервера

        /// <summary>Отключиться от сервера</summary>
        private ICommand _DisconnectCommand;

        /// <summary>Отключиться от сервера</summary>
        public ICommand DisconnectCommand => _DisconnectCommand
            ??= new LambdaCommandAsync(OnDisconnectCommandExecuted, CanDisconnectCommandExecute);

        /// <summary>Проверка возможности выполнения - Отключиться от сервера</summary>
        private bool CanDisconnectCommandExecute() => _InformationService.Connected;

        /// <summary>Логика выполнения - Отключиться от сервера</summary>
        private async Task OnDisconnectCommandExecuted() => await _InformationService.Disconnect();

        #endregion

        #region Command SendCommand - Отправить сообщение

        /// <summary>Отправить сообщение</summary>
        private ICommand _SendCommand;

        /// <summary>Отправить сообщение</summary>
        public ICommand SendCommand => _SendCommand
            ??= new LambdaCommandAsync(OnSendCommandExecuted, CanSendCommandExecute);

        /// <summary>Проверка возможности выполнения - Отправить сообщение</summary>
        private bool CanSendCommandExecute() => 
            _InformationService.Connected
            && !string.IsNullOrWhiteSpace(UserName) 
            && !string.IsNullOrWhiteSpace(Message);

        /// <summary>Логика выполнения - Отправить сообщение</summary>
        private async Task OnSendCommandExecuted()
        {
            await _InformationService.Invoke("InputMessage", UserName, Message);
        }

        #endregion

        #endregion

        public MainWindowViewModel(IOptions<AppSettings> Options, IInformationService InformationService)
        {
            _InformationService = InformationService;
            Title = Options.Value.Title;
        }

        private void OnChatMessageReceived(string User, string Message)
        {
            var message = new UserMessage(User, Message);
            Messages.Add(message);
        }
    }
}
