using MSAFORO255.Withtdrawal.Model;

namespace MSAFORO255.Withtdrawal.Repository
{
    public interface ITransactionRepository
    {

        Transaction Withtdrawal(Transaction transaction);
        Transaction WithtdrawalReverse(Transaction transaction);
    }
}
