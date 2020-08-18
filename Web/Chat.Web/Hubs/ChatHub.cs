namespace Chat.Web.Hubs
{
    using Chat.Web.Models.Chat;
    using Microsoft.AspNetCore.SignalR;
    using System.Threading.Tasks;

    public class ChatHub : Hub
    {
        public async Task Send(string message)
        {
            await this.Clients.All.SendAsync(
                "NewMessage",
                new Message { 
                    User = this.Context.User.Identity.Name, 
                    Text = message, 
                });
        }
    }
}
