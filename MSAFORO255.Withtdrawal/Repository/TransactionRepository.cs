using MSAFORO255.Withtdrawal.Model;
using MSAFORO255.Withtdrawal.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSAFORO255.Withtdrawal.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IContextDatabase _contextDatabase;

        public TransactionRepository(IContextDatabase contextDatabase)
        {
            _contextDatabase = contextDatabase;
        }
        public Transaction Withtdrawal(Transaction transaction)
        {
            _contextDatabase.Transaction.Add(transaction);
            _contextDatabase.SaveChanges();
            return transaction;
        }

        public Transaction WithtdrawalReverse(Transaction transaction)
        {
            _contextDatabase.Transaction.Add(transaction);
            _contextDatabase.SaveChanges();
            return transaction;
        }
    }
}
