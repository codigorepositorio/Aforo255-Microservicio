using MSAFORO255.Deposit.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSAFORO255.Deposit.Service
{
    public interface ITransactionService
    {
        Transaction Deposit(Transaction transaction);
        Transaction DepositReverse(Transaction transaction);
    }
}
