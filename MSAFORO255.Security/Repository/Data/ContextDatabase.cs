using Microsoft.EntityFrameworkCore;
using MSAFORO255.Security.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
