using MSAFORO255.Security.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSAFORO255.Security.Service
{
   public interface IAccessService
    {
        IEnumerable<Access> GetAll();
        bool Validate(string userName, string password);        
    }
}
