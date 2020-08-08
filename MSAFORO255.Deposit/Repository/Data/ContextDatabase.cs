using Microsoft.EntityFrameworkCore;
using MSAFORO255.Deposit.Model;

namespace MSAFORO255.Deposit.Repository.Data
{
    public class ContextDatabase : DbContext, IContextDatabase
    {
        public ContextDatabase( DbContextOptions<ContextDatabase> options) : base(options)
        {

        }

        public DbSet<Transaction> Transaction { get; set; }
        
    }
}
