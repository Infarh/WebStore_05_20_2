using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using WebStore.WPF.ViewModels.Base;

namespace WebStore.WPF.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Свойства

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

        #endregion

        #region Команды

        #endregion

        public MainWindowViewModel(IOptions<AppSettings> Options)
        {
            Title = Options.Value.Title;
        }
    }
}
