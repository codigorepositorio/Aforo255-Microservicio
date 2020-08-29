using MongoDB.Driver;
using MSAFORO255.History.DTO;
using MSAFORO255.History.Model;
using MSAFORO255.History.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSAFORO255.History.Service
{
    public class HistoryService : IHistoryService
    {
        private readonly IRepositoryHistory _repositoryHistory;

        public HistoryService(IRepositoryHistory repositoryHistory)
        {
            _repositoryHistory = repositoryHistory;
        }
        public async Task<bool> Add(HistoryTransaction historyTransaction)
        {
            await _repositoryHistory.HistoryCredit.InsertOneAsync(historyTransaction);
            return true;
        }

        public async Task<IEnumerable<HistoryResponse>> GetAll()
        {
            var data = await _repositoryHistory.HistoryCredit.Find(_ => true).ToListAsync();

            var response = new List<HistoryResponse>();
            foreach (var item in data)
            {
                response.Add(new HistoryResponse()
                {
                    AccountId = item.AccountId,
                    Amount = item.Amount,
                    CreationDate = item.CreationDate,
                    IdTransaction = item.IdTransaction,
                    Type = item.Type
                });
            }
            return response;
        }
    }
}
