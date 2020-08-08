using MSAFORO255.Deposit.Model;

namespace MSAFORO255.Deposit.Repository
{
    public interface ITransactionRepository
    {

        Transaction Deposit(Transaction transaction);
        Transaction DepositReverse(Transaction transaction);
    }
}
