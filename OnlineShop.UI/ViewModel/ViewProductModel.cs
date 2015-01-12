using OnlineShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.UI.ViewModel
{
    public class ViewProductModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string PhotoString { get; set; }
        public string sDescription { get; set; }
        public string fDescription { get; set; }
        public string Warranty { get; set; }
        public string Discount { get; set; }
        public int CategoryID { get; set; }
        public string PColor { get; set; }
        public DateTime ProductAddDate { get; set; }
        public virtual Category Category { get; set; }
        public IEnumerable<Product> products { get; set; }
    }
}