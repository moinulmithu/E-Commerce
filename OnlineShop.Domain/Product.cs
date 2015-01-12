using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [MaxLength(50, ErrorMessage = "Product Name must be between 3 to 50 character.")]
        [MinLength(3, ErrorMessage = "Product Name must be between 3 to 50 character.")]
        [Required]
        public string ProductName { get; set; }
        [MaxLength(200, ErrorMessage = "Product short Description must be between 50 to 200 character.")]
        [MinLength(50, ErrorMessage = "Product short Description must be between 50 to 200 character.")]       
        public string ShortDescription { get; set; }
        [MaxLength(500, ErrorMessage = "Product full Description must be between 50 to 500 character.")]
        [MinLength(50, ErrorMessage = "Product full Description must be between 50 to 500 character.")]
        public string FullDescription { get; set; }
        public byte[] ProductImage { get; set; }
        public string  ImageMT { get; set; }
        [Required]
        public decimal Price { get; set; }
        [MaxLength(20, ErrorMessage = "Product Warranty must be less then 20 character.")]
        public string Warranty { get; set; }
        //public bool Featured { get; set; }
        //public bool OnSale { get; set; }
        [MaxLength(20, ErrorMessage = "Product Discount must be less then 20 character.")]
        public string Discount{ get; set; }
        [MaxLength(20, ErrorMessage = "Product Color must be less then 20 character.")]
        public string ProductColor { get; set; }
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public DateTime ProductAddDate {get;set;}
        public virtual Category Category { get; set; }


    }
}
