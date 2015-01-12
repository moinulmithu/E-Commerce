using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain
{
    public class OrderItem
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Order")]
        public int OrderID { get; set; }
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
