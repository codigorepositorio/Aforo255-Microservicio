using Microsoft.EntityFrameworkCore;

using MSAFORO255.Deposit.Model;

namespace MSAFORO255.Deposit.Repository.Data
{
    public interface IContextDatabase
    {
        DbSet<Transaction> Transaction { get; set; }

        int SaveChanges();
    }
}
