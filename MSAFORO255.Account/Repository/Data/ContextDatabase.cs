using Microsoft.EntityFrameworkCore;
using MSAFORO255.Account.Model;

namespace MSAFORO255.Account.Repository.Data
{
    public class ContextDatabase : DbContext, IContextDatabase
    {
        public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options) { }

        public DbSet<Model.Account> Account { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbContext Instance => this;
    }
}
