using MSAFORO255.Deposit.Model;

namespace MSAFORO255.Deposit.Service
{
    public interface ITransactionService
    {
        Transaction Deposit(Transaction transaction);
        Transaction DepositReverse(Transaction transaction);
    }
}
