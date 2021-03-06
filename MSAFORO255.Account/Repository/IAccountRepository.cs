﻿using System.Collections.Generic;

namespace MSAFORO255.Account.Repository
{
    public interface IAccountRepository
    {
        IEnumerable<Model.Account> GetAll(); //Obtener las cuentas.
        bool Deposit(Model.Account account);  //Hacer un deposito.
        bool Withdrawal(Model.Account account);  //Retiro de cuenta.
    }
}

