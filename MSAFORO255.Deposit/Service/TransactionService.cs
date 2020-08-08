using MSAFORO255.Deposit.Model;
using MSAFORO255.Deposit.Repository;


namespace MSAFORO255.Deposit.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public bool Deposit(Transaction transaction)
        {
            _transactionRepository.Deposit(transaction);
            return true;
        }
    }
}
