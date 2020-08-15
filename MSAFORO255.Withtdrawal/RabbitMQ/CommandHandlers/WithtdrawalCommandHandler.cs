using MediatR;
using MS.AFORO255.Cross.RabbitMQ.Src.Bus;
using MSAFORO255.Withtdrawal.RabbitMQ.Commands;
using MSAFORO255.Withtdrawal.RabbitMQ.Events;
using System.Threading;
using System.Threading.Tasks;

namespace MSAFORO255.Withtdrawal.RabbitMQ.CommandHandlers
{
    public class WithtdrawalCommandHandler : IRequestHandler<WithtdrawalCreateCommand, bool>
    {
        private readonly IEventBus _bus;

        public WithtdrawalCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }
        public Task<bool> Handle(WithtdrawalCreateCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new WithtdrawalCreatedEvent(
                request.IdTransaction,
                request.Amount,
                request.Type,
                request.CreationDate,
                request.AccountId
                ));

            return Task.FromResult(true);
        }
    }
}
