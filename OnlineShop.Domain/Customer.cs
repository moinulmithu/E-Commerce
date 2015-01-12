using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public int? UserID { get; set; }
        [MaxLength(40)]
        public string FullName { get; set; }
        public string EmailID { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }           
        public string CcNumber { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
