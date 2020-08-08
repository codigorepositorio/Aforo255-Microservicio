;
using System.Threading.Tasks;

namespace MSAFORO255.Withtdrawal.RabbitMQ.EventHandlers
{
    public class DepositEventHandler : IEventHandler<DepositCreatedEvent>
    {
        private readonly IWithtdrawalService _historyService;

        public DepositEventHandler(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        public Task Handle(DepositCreatedEvent @event)
        {
            _historyService.Add(new HistoryTransaction()
            {
                IdTransaction = @event.IdTransaction,
                Amount = @event.Amount,
                Type = @event.Type,
                CreationDate = @event.CreationDate,
                AccountId = @event.AccountId

            });
            return Task.CompletedTask;
        }
    }
}