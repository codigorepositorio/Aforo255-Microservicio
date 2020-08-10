using Microsoft.EntityFrameworkCore;
using MSAFORO255.Notification.Model;

namespace MSAFORO255.Notification.Repository.Data
{
    public class ContextDatabase : DbContext, IContextDatabase
    {
        public ContextDatabase( DbContextOptions<ContextDatabase> options) : base(options)
        {

        }

        public DbSet<SendMail> SendMail { get; set; }
        public DbContext Instance => this;


    }
}
