namespace Chat.Web.Data
{
    using Chat.Web.Models.Chat;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ChatDbContext : IdentityDbContext<ChatUser>
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> options)
            : base(options)
        {
        }
    }
}
