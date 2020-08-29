
using MongoDB.Driver;
using MSAFORO255.History.Model;

namespace MSAFORO255.History.Repository
{
    public interface IRepositoryHistory
    {
     IMongoCollection<HistoryTransaction> HistoryCredit { get; }
    }
}
