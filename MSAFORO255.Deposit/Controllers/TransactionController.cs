using System;
using Microsoft.AspNetCore.Mvc;
using MS.AFORO255.Cross.RabbitMQ.Src.Bus;
using MSAFORO255.Deposit.DTO;
using MSAFORO255.Deposit.RabbitMQ.Commands;
using MSAFORO255.Deposit.Service;

namespace MSAFORO255.Deposit.Controllers
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

        [HttpPost("Deposit")]
        public IActionResult Get([FromBody] TransactionRequest request)
        {
            Model.Transaction transaction = new Model.Transaction()
            {
                AccountId = request.AccountId,
                Amount = request.Amount,
                CreationDate = DateTime.Now.ToString(),
                Type = "Deposit"
            };
            transaction =  _transactionService.Deposit(transaction);

            var createCommand = new DepositCreateCommand(
                idTransaction: transaction.Id,
                amount: transaction.Amount,
                type: transaction.Type,
                creationDate: transaction.CreationDate,
                accountId: transaction.AccountId
                );

            _bus.SendCommand(createCommand);

            return Ok(new { transaction.Id });
        }
    }
}
