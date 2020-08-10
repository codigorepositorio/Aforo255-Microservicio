
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MSAFORO255.Deposit.Model;

namespace MSAFORO255.History.Repository
{
    public class RepositoryHistory : IRepositoryHistory
    {
        private readonly IMongoDatabase _database = null;

        public RepositoryHistory(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["mongo:cn"]);
            if (client != null)
                _database = client.GetDatabase(configuration["mongo:database"]);
        }
        public IMongoCollection<HistoryTransaction> HistoryCredit
        {
            get
            {
                return _database.GetCollection<HistoryTransaction>("HistoryTransaction");
            }
        }
    }
}
