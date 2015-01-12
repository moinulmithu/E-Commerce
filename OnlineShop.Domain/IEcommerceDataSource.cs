using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain
{
    public interface IEcommerceDataSource
    {
         IQueryable<Category> Categories { get; set; }
         IQueryable<Product> Products { get; set; }
         IQueryable<Cart> Carts { get; set; }
         IQueryable<Customer> Customers { get; set; }
         IQueryable<Order> Orders { get; set; }
         IQueryable<OrderItem> OrderItems { get; set; }
    }
}
