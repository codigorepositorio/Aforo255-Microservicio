using MSAFORO255.Deposit.Model;
using MSAFORO255.Deposit.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSAFORO255.Deposit.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IContextDatabase _contextDatabase;

        public TransactionRepository(IContextDatabase contextDatabase)
        {
            _contextDatabase = contextDatabase;
        }
        public bool Deposit(Transaction transaction)
        {
             _contextDatabase.Transaction.Add(transaction);
            _contextDatabase.SaveChanges();
            return true;
        }
    }
}
