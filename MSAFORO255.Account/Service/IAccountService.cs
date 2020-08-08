using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSAFORO255.Account.Service
{
 public  interface IAccountService
    {
        IEnumerable<Model.Account> GetAll(); //Obtener las cuentas.
        bool Deposit(Model.Account account);  //Hacer un deposito.
        bool Withdrawal(Model.Account account);  //Retiro de cuenta.
    }
}
