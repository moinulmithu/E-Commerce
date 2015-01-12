using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [MaxLength(50,ErrorMessage = "Category Name must be less then or equal 50 character.")]
        [ConcurrencyCheck]
        [Required]
        public string CategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}
