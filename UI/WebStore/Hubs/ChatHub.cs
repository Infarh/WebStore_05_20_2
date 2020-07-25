using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace WebStore.Hubs
{
    public class ChatHub : Hub
    {
        public async Task InputMessage(string User, string Message) => await Clients.All.SendAsync("OutputMessage", User, Message);
    }
}
