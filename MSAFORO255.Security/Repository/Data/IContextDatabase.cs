using Microsoft.EntityFrameworkCore;
using MSAFORO255.Security.Model;

namespace MSAFORO255.Security.Repository.Data
{
    public interface IContextDatabase
    {
        DbSet<Access> Access { get; set; }
    }
}
