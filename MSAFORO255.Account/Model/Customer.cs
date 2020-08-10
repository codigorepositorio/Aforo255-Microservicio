using System.ComponentModel.DataAnnotations;

namespace MSAFORO255.Account.Model
{
    public class Customer
    {
        [Key]
        public int IdCustomer  { get; set; }
        public string FullName { get; set; }       
    }
}
