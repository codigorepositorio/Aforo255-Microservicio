using MSAFORO255.Withtdrawal.DTO;
using MSAFORO255.Withtdrawal.Model;
using System.Threading.Tasks;

namespace MSAFORO255.Withtdrawal.Service
{
    public interface IAccountService
    {
        Task<bool> WithtdrawalAccount(AccountRequest request);
        bool WithtdrawalReverse(Transaction request);
        bool Execute(Transaction request);

    }
}
