using MSAFORO255.Withtdrawal.Model;
using MSAFORO255.Withtdrawal.Repository;


namespace MSAFORO255.Withtdrawal.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public Transaction Withtdrawal(Transaction transaction)
        {
            _transactionRepository.Withtdrawal(transaction);
            return transaction;
        }

        public Transaction WithtdrawalReverse(Transaction transaction)
        {
            _transactionRepository.WithtdrawalReverse(transaction);
            return transaction;
        }
    }
}
