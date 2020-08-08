using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSAFORO255.Deposit.RabbitMQ.Commands
{
    public class DepositCommand 
    {
        public int IdTransaction { get; protected set; }
        public decimal Amount { get; protected set; }
        public string Type { get; protected set; }
        public string CreationDate { get; protected set; }
        public int AccountId { get; protected set; }
    }
}
