using MSAFORO255.Deposit.Model;

namespace MSAFORO255.Deposit.Repository
{
    public interface ITransactionRepository
    {

        bool Deposit(Transaction transaction);
    }
}
