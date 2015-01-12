using OnlineShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.UI.ViewModel
{

        public class CategiesAndProduct
        {
            public IEnumerable<Category> Categories { get; set; }
            public IEnumerable<Product> Products { get; set; }
        }
        public class CategoriesAndProductDetail
        {
            public IEnumerable<Category> Categories { get; set; }
            public Product Product { get; set; }
        }

        public class CartView
        {
            public int UserID { get; set; }
            public int CartID { get; set; }
            public IList<Cart> CartItems { get; set; }
            public decimal Total { get; set; }
        }
        public class PreOrderView
        {
            public CartView Cart { get; set; }
            public Customer CustomerDetail { get; set; }
        }
        public class ProductView
        {
            public IEnumerable<Category> Categories { get; set; }
            public Product Product { get; set; }
        }
        public class OrderView
        {
            public int OrderID { get; set; }
            public string CustomerName { get; set; }
            public string OrderDate { get; set; }
            public string Status { get; set; }
            public string ShippedDate { get; set; }
            public decimal OrderValue { get; set; }

    }
}