using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain
{
   public class Payment
    {
       [Key]
        public int PaymentID { get; set; }
       [Required]
        public int CustomerID { get; set; }
       [Required]
       [MaxLength(30, ErrorMessage = "Product Name must be between 4 to 30 character.")]
       [MinLength(4, ErrorMessage = "Product Name must be between 4 to 30 character.")]
        public string CheckNumber { get; set; }
       [Required]
        public DateTime PaymentDate { get; set; }
       [Required]
        public decimal PaymentAmmount { get; set; }

    }
}
