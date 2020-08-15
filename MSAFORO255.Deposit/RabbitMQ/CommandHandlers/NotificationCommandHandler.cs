using MediatR;
using MS.AFORO255.Cross.RabbitMQ.Src.Bus;
using MSAFORO255.Deposit.RabbitMQ.Commands;
using MSAFORO255.Deposit.RabbitMQ.Events;
using System.Threading;
using System.Threading.Tasks;

namespace MSAFORO255.Deposit.RabbitMQ.CommandHandlers
{
    public class NotificationCommandHandler : IRequestHandler<NotificationCreateCommand, bool>
    {
        private readonly IEventBus _bus;

        public NotificationCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }
        public Task<bool> Handle(NotificationCreateCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new NotificationCreatedEvent(
                request.IdTransaction,
                request.Amount,
                request.Type,                
                request.AccountId
                ));

            return Task.FromResult(true);
        }
    }
}
