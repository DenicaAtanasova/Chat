namespace Chat.Web.Hubs
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.SignalR;

    using Ganss.XSS;
    using Chat.Data.Models;

    public class ChatHub : Hub
    {
        private readonly IHtmlSanitizer _htmlSanitizer;

        public ChatHub(IHtmlSanitizer htmlSanitizer)
        {
            this._htmlSanitizer = htmlSanitizer;
        }

        public async Task Send(string message)
        {
            var sanitizedMessage = _htmlSanitizer.Sanitize(message);

            await this.Clients.All.SendAsync(
                "NewMessage",
                new Message { 
                    User = this.Context.User.Identity.Name, 
                    Text = sanitizedMessage, 
                });
        }
    }
}
