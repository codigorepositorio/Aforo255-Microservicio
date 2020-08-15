using MSAFORO255.Deposit.DTO;
using MSAFORO255.Deposit.Model;
using System.Threading.Tasks;

namespace MSAFORO255.Deposit.Service
{
    public interface IAccountService
    {
        Task<bool> DepositAccount(AccountRequest request);
        bool DepositReverse(Transaction request);
        bool Execute(Transaction request);

    }
}
