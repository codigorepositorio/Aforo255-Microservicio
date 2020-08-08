using Microsoft.EntityFrameworkCore;

using MSAFORO255.Withtdrawal.Model;

namespace MSAFORO255.Withtdrawal.Repository.Data
{
    public interface IContextDatabase
    {
        DbSet<Transaction> Transaction { get; set; }

        int SaveChanges();
    }
}
