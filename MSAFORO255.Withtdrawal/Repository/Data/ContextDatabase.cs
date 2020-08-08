using Microsoft.EntityFrameworkCore;
using MSAFORO255.Withtdrawal.Model;

namespace MSAFORO255.Withtdrawal.Repository.Data
{
    public class ContextDatabase : DbContext, IContextDatabase
    {
        public ContextDatabase( DbContextOptions<ContextDatabase> options) : base(options)
        {

        }

        public DbSet<Transaction> Transaction { get; set; }
        
    }
}
