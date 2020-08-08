using MSAFORO255.Withtdrawal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSAFORO255.Withtdrawal.Service
{
    public interface ITransactionService
    {
        Transaction Withtdrawal(Transaction transaction);
        Transaction WithtdrawalReverse(Transaction transaction);
    }
}
