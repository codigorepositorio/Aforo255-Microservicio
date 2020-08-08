using Microsoft.EntityFrameworkCore;
using MSAFORO255.Account.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSAFORO255.Account.Repository
{
    public class AccountRepository : IAccountRepository

    {
        private readonly IContextDatabase _contextDatabase;

        public AccountRepository(IContextDatabase contextDatabase)
        {
            _contextDatabase = contextDatabase;
        }
        public bool Deposit(Model.Account account)
        {
            _contextDatabase.Account.Update(account);
            _contextDatabase.SaveChanges();
            return true;
        }

        public IEnumerable<Model.Account> GetAll()
        {
            return _contextDatabase
                  .Account
                  .Include(c => c.Customer)
                  .AsNoTracking()
                  .ToList();


        }

        public bool Withdrawal(Model.Account account)
        {
            _contextDatabase.Account.Update(account);
            _contextDatabase.SaveChanges();
            return true;
        }
    }
}
