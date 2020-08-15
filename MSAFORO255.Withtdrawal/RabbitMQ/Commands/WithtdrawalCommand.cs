using MS.AFORO255.Cross.RabbitMQ.Src.Commands;

namespace MSAFORO255.Withtdrawal.RabbitMQ.Commands
{
    public class WithtdrawalCommand : Command
    {
        public int IdTransaction { get; protected set; }
        public decimal Amount { get; protected set; }
        public string Type { get; protected set; }
        public string CreationDate { get; protected set; }
        public int AccountId { get; protected set; }
    }
}
