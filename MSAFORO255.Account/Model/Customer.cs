using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MSAFORO255.Account.Model
{
    public class Customer
    {
        [Key]
        public int IdCustomer  { get; set; }
        public string FullName { get; set; }       
    }
}
