using Microsoft.EntityFrameworkCore;
using MSAFORO255.Security.Model;

namespace MSAFORO255.Security.Repository.Data
{
    public class ContextDatabase : DbContext, IContextDatabase
    {
        public ContextDatabase( DbContextOptions<ContextDatabase> options) : base(options)
        {

        }

        public DbSet<Access> Access { get; set; }
    }
}
