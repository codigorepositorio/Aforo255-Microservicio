using MSAFORO255.Security.Model;
using MSAFORO255.Security.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSAFORO255.Security.Service
{
    public class AccessService : IAccessService
    {
        private readonly IAccessRepository _accessRepository;

        public AccessService(IAccessRepository accessRepository)
        {
            _accessRepository = accessRepository;
        }

        public IEnumerable<Access> GetAll()
        {
            return _accessRepository.GetAll();
        }

        public bool Validate(string userName, string password)
        {
            var list = _accessRepository.GetAll();
            var access = list.Where(x => x.Username == userName && x.Password == password)
                .FirstOrDefault();
            if (access != null)
                return true;
            return false;
        }
    }
}
