using Microsoft.Extensions.Configuration;
using MS.AFORO255.Cross.Proxy.Proxy;
using MSAFORO255.Deposit.DTO;
using MSAFORO255.Deposit.Model;
using Polly;
using Polly.CircuitBreaker;
using System;
using System.Threading.Tasks;

namespace MSAFORO255.Deposit.Service
{
    public class AccountService : IAccountService
    {
        private readonly ITransactionService _transactionService;
        private readonly IHttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public AccountService(ITransactionService transactionService, 
            IHttpClient httpClient, IConfiguration configuration)
        {
            _transactionService = transactionService;
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<bool> DepositAccount(AccountRequest request)
        {
            string uri = _configuration["proxy:urlAccountDeposit"];
            var response = await _httpClient.PostAsync(uri, request);
            response.EnsureSuccessStatusCode();
            return true;
        }

        public bool DepositReverse(Transaction request)
        {
            _transactionService.DepositReverse(request);
            return true;
        }

        public bool Execute(Transaction request)
        {

            bool response = false;
            //#1. Pòlitica de CircuiBraker

            var circuitBrakerPolicy = Policy.Handle<Exception>() 
                .CircuitBreaker(3, TimeSpan.FromSeconds(15),
                onBreak: (ex, timeSpan, context) =>
                 {
                     Console.Write("El circuito entro en estado de falla");
                 },
                 onReset: (context) =>
                  {
                      Console.Write("Circuito dejo estado de falla");
                  });

            //#2 Pòlitica de reitentos
            var retry = Policy.Handle<Exception>()
                .WaitAndRetryForever(attemp => TimeSpan.FromMilliseconds(300))
                .Wrap(circuitBrakerPolicy);//Se antepone esta Politica de CircuiBraker.

            //#3 La ejecuciòn de Reitentos.
            retry.Execute(() =>
             {
                 if (circuitBrakerPolicy.CircuitState == CircuitState.Closed)
                 {
                     circuitBrakerPolicy.Execute(() =>
                     {
                         AccountRequest account = new AccountRequest()
                         {
                             Amount = request.Amount,
                             IdAccount = request.AccountId
                         };
                         response = DepositAccount(account).Result;
                         Console.WriteLine("Solicitud realizada con èxito");
                     });

                 }//fin del IF


                 if (circuitBrakerPolicy.CircuitState != CircuitState.Closed)
                 {

                     Transaction transaction = new Transaction()
                     {
                         Amount = request.Amount,                         
                         CreationDate = DateTime.Now.ToString(),
                         AccountId = request.AccountId,
                         Type ="Deposit R",
                     };

                     response = DepositReverse(transaction);
                     response = false;
                     Console.WriteLine("Solicitud cancelada con èxito");

                 }//fin del IF

             });//Fin Retry

            return response;
        }
    }
}
