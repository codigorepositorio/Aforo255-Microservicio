using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MSAFORO255.Account.DTO;
using MSAFORO255.Account.Service;

namespace MSAFORO255.Account.Controllers
{
    [Route("api/Account")]
    [ApiController]
    //[Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accounService;

        public AccountController(IAccountService accounService)
        {
            _accounService = accounService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_accounService.GetAll());
        }

        [HttpPost("Deposit")]
        public IActionResult Deposit([FromBody] AccountRequest request)
        {

            var result = _accounService.GetAll().Where(x => x.IdAccount == request.IdAccount).FirstOrDefault();

            Model.Account account = new Model.Account()
            {
                IdAccount = request.IdAccount,
                IdCustomer = result.IdCustomer,
                TotalAmount = result.TotalAmount + request.Amount,
                Customer = result.Customer
            };
            _accounService.Deposit(account);
            return Ok();
        }


        [HttpPost("Withdrawal")]
        public IActionResult Withdrawal([FromBody] AccountRequest request)
        {

            var result = _accounService.GetAll().Where(x => x.IdAccount == request.IdAccount).FirstOrDefault();

            if (result.TotalAmount < request.Amount)
            {
                return BadRequest(new {message= "The indicated amount cannot be Withdrawal" });
            }

            Model.Account account = new Model.Account()
            {
                IdAccount = request.IdAccount,
                IdCustomer = result.IdCustomer,
                TotalAmount = result.TotalAmount - request.Amount,
                Customer = result.Customer
            };
            _accounService.Withdrawal(account);
            return Ok();
        }


    }

}

