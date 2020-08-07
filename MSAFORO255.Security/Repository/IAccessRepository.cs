using MSAFORO255.Security.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace MSAFORO255.Security.Repository
{
    public interface IAccessRepository
    {

        IEnumerable<Access> GetAll();

    }
}
