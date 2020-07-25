using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.WPF.Models
{
    class UserMessage
    {
        public DateTime Time { get; set; } = DateTime.Now;

        public string User { get; set; }

        public string Message { get; set; }

        public UserMessage() { }

        public UserMessage(string User, string Message)
        {
            this.User = User;
            this.Message = Message;
        }
    }
}
