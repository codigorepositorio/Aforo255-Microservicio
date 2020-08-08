using MSAFORO255.Deposit.DTO;
using MSAFORO255.Deposit.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSAFORO255.History.Service
{
    public interface IHistoryService
    {
        Task<IEnumerable<HistoryResponse>> GetAll();
        Task<bool> Add(HistoryTransaction historyTransaction);

    }
}
