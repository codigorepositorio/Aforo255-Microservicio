using MSAFORO255.Security.Model;
using MSAFORO255.Security.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSAFORO255.Security.Repository
{
   public class AccessRepository : IAccessRepository
    {
        private readonly IContextDatabase _contextDatabase;

        public AccessRepository(IContextDatabase contextDatabase)
        {
            _contextDatabase = contextDatabase;
        }

        public IEnumerable<Access> GetAll()
        {
            return _contextDatabase.Access.ToList();
        }

    }
}
