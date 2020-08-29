using MS.AFORO255.Cross.RabbitMQ.Src.Bus;
using MSAFORO255.Notification.Model;
using MSAFORO255.Notification.RabbitMQ.Events;
using MSAFORO255.Notification.Repository;
using System.Threading.Tasks;
using System;
namespace MSAFORO255.Notification.RabbitMQ.EventHandler
{
    public class NotificationEventHandler : IEventHandler<NotificationCreatedEvent>
    {
        private readonly IMailRepository _mailRepository;
        public NotificationEventHandler(IMailRepository mailRepository)
        {
            _mailRepository = mailRepository;
        }

        public Task Handle(NotificationCreatedEvent @event)
        {
            _mailRepository.Add(new SendMail()
            {
                SendMailId = @event.IdTransaction,
                SendDate = DateTime.Now.ToShortDateString(),
                AccountId = @event.AccountId
            }); ;

            return Task.CompletedTask;
        }
    }
}
