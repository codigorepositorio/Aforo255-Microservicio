
using MongoDB.Driver;
using MSAFORO255.Deposit.Model;

namespace MSAFORO255.History.Repository
{
    public interface IRepositoryHistory
    {
     IMongoCollection<HistoryTransaction> HistoryCredit { get; }
    }
}
