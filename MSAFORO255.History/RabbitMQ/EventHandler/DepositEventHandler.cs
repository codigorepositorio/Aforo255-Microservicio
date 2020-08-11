using MS.AFORO255.Cross.RabbitMQ.Src.Bus;
using MSAFORO255.Deposit.Model;
using MSAFORO255.History.RabbitMQ.Events;
using MSAFORO255.History.Service;
using System.Threading.Tasks;

namespace MSAFORO255.History.RabbitMQ.EventHandler
{
    public class DepositEventHandler : IEventHandler<DepositCreatedEvent>
    {
        private readonly IHistoryService _historyService;

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
