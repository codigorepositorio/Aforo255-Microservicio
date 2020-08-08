using Microsoft.EntityFrameworkCore;
using MSAFORO255.Account.Model;

namespace MSAFORO255.Account.Repository.Data
{
    public interface IContextDatabase
    {
        DbSet<Model.Account>  Account { get; set; }
        DbSet<Customer> Customer { get; set; }
        int SaveChanges();
    }
}
