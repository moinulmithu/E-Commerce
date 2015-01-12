using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }
        public int UserId { get; set; }
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public int Quantitity { get; set; }
        public Product Product { get; set; }
    }
}
