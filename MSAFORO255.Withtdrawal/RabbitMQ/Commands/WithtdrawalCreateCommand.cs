namespace MSAFORO255.Withtdrawal.RabbitMQ.Commands
{
    public class WithtdrawalCreateCommand : WithtdrawalCommand
    {
        public WithtdrawalCreateCommand(int idTransaction, decimal amount,
        string type, string creationDate, int accountId)
        {
            IdTransaction = idTransaction;
            Amount = amount;
            Type = type;
            CreationDate = creationDate;
            AccountId = accountId;
        }
    }
}
