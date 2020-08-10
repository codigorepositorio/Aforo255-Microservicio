using Microsoft.EntityFrameworkCore;
using MSAFORO255.Notification.Model;

namespace MSAFORO255.Notification.Repository.Data
{
    public interface IContextDatabase
    {
        DbSet<SendMail> SendMail { get; set; }
        int SaveChanges();
    }
}
