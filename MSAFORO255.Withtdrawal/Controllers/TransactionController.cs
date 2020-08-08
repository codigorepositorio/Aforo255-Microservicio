﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSAFORO255.Withtdrawal.DTO;
using MSAFORO255.Withtdrawal.Service;

namespace MSAFORO255.Withtdrawal.Controllers
{
    [Route("api/Transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
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
            return Ok(new { transaction.Id });
        }

    }
}