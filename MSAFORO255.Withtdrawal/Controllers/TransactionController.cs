using System;
using Microsoft.AspNetCore.Mvc;
using MS.AFORO255.Cross.RabbitMQ.Src.Bus;
using MSAFORO255.Withtdrawal.DTO;
using MSAFORO255.Withtdrawal.RabbitMQ.Commands;
using MSAFORO255.Withtdrawal.Service;

namespace MSAFORO255.Withtdrawal.Controllers
{
    [Route("api/Transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IEventBus _bus;

        public TransactionController(ITransactionService transactionService, IEventBus bus)
        {
            _transactionService = transactionService;
            _bus = bus;
        }

        [HttpPost("Withtdrawal")]
        public IActionResult Get([FromBody] TransactionRequest request)
        {
            Model.Transaction transaction = new Model.Transaction()
            {
                AccountId = request.AccountId,
                Amount = request.Amount,
                CreationDate = DateTime.Now.ToString(),
                Type = "Retiro"
            };
            transaction =  _transactionService.Withtdrawal(transaction);
            var createdCommand = new WithtdrawalCreateCommand(
                
                idTransaction:transaction.Id,
                amount:transaction.Amount,
                type:transaction.Type,
                creationDate:transaction.CreationDate,
                accountId:transaction.AccountId
                );
            _bus.SendCommand(createdCommand);

            var createCommandNotification = new NotificationCreateCommand(
            idTransaction: transaction.Id,
            amount: transaction.Amount,
            type: transaction.Type,
            accountId: transaction.AccountId
            );

            _bus.SendCommand(createCommandNotification);

            return Ok(new { transaction.Id });
        }

    }
}
