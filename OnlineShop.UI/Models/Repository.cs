using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShop.Domain;
using OnlineShop.UI.Infrastructure;
using System.Data;


namespace OnlineShop.UI.Models
{
    public class Repository
    {
        EcommerceContex _ctx;
        public Repository()
        {
            _ctx = new EcommerceContex();
        }
        public IEnumerable<Category> GetAll()
        {
            return _ctx.Categories.ToList();
        }
        public IEnumerable<Category> Get(int id)
        {
            return GetAll().Where(c => c.CategoryID == id).ToList();
        }
        public void AddCategory(Category category)
        {
            _ctx.Categories.Add(category);
            _ctx.SaveChanges();
        }
        public IEnumerable<Product> GetProductsAll()
        {
            return _ctx.Products.ToList();
        }
        public IEnumerable<Product> GetProductOfCategory(int id)
        {
            return GetProductsAll().Where(p => p.CategoryID == id).ToList();
        }
        public Product GetProductById(int id)
        {
            return GetProductsAll().FirstOrDefault(p => p.ProductID == id);
        }
        public void AddProduct(Product product)
        {
            _ctx.Products.Add(product);
            _ctx.SaveChanges();
        }
        public IEnumerable<Cart> GetCart(int? UserID)
        {
            return _ctx.Carts.Include("Product").Where(c => c.UserId == UserID).ToList();
        }
        public IEnumerable<Cart> AddToCart(int UserID, int ProductID, int Qty = 1)
        {
            if (_ctx.Carts.Where(c => c.UserId == UserID && c.ProductID == ProductID).Count() > 0)
            {
                _ctx.Carts.First(c => c.UserId == UserID && c.ProductID == ProductID).Quantitity += Qty;
            }
            else
            {
                _ctx.Carts.Add(new Cart { UserId = UserID, ProductID = ProductID, Quantitity = 1 });
            }
            _ctx.SaveChanges();
            return _ctx.Carts.Include("Product").Where(c => c.UserId == UserID).ToList();

        }
        public void AddEntryToCustomer(int UserID)
        {
            _ctx.Customers.Add(new Customer { UserID = UserID });
            _ctx.SaveChanges();
        }
        public Customer GetCustomerByKey(int UserID)
        {
            return _ctx.Customers.FirstOrDefault(c => c.UserID == UserID);
        }
        public void UpadteCart(int CartID, int qty)
        {
            Cart cart = _ctx.Carts.FirstOrDefault(c => c.CartID == CartID);
            if (cart != null)
            {
                cart.Quantitity = qty;
                _ctx.SaveChanges();
            }

        }
        public void UpdateCustomer(Customer customer)
        {
            Customer orignal = _ctx.Customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);
            if (orignal != null)
            {
                orignal.FullName = customer.FullName;
                orignal.Address = customer.Address;
                orignal.CcNumber = customer.CcNumber;
                orignal.EmailID = customer.EmailID;
                _ctx.SaveChanges();
            }
        }
        public void CreateOrder(int UserID)
        {
            int CustomerID = GetCustomerByKey(UserID).CustomerID;
            Order order = new Order
            {
                CustomerID = CustomerID,
                OrderDate = DateTime.Now

            };
            _ctx.Orders.Add(order);
            _ctx.SaveChanges();
            var carts = GetCart(UserID);
            foreach (var cart in carts)
            {
                _ctx.OrderItems.Add(new OrderItem { ProductID = cart.ProductID, Quantity = cart.Quantitity, OrderID = order.OrderID });
                _ctx.Entry(cart).State = EntityState.Deleted;
            }
            _ctx.SaveChanges();
        }
        public IEnumerable<Order> GetOrders()
        {
            return _ctx.Orders.Include("Customer").Include("OrderItems").Include("OrderItems.Product").ToList();
        }
        public IEnumerable<Order> GetPendingOrders()
        {
            return _ctx.Orders.Include("Customer").Include("OrderItems").Include("OrderItems.Product").Where(o => o.ShipDate == null).ToList();
        }
        public IEnumerable<Order> GetShippedOrders()
        {
            return _ctx.Orders.Include("Customer").Include("OrderItems").Include("OrderItems.Product").Where(o => o.ShipDate != null).ToList();
        }
        public IEnumerable<Order> GetOrdersByDate(DateTime date)
        {
            return _ctx.Orders.Include("Customer").Include("OrderItems").Include("OrderItems.Product").Where(o => o.OrderDate.Year == date.Year && o.OrderDate.Month == date.Month && o.OrderDate.Day == date.Day).ToList();
        }
        public Order GetOrderByID(int OrderID)
        {
            return _ctx.Orders.Include("Customer").Include("OrderItems").Include("OrderItems.Product").FirstOrDefault(o => o.OrderID == OrderID);
        }
        public void UpdateOrder(int OrderID, DateTime? ShipDate)
        {
            _ctx.Orders.First(o => o.OrderID == OrderID).ShipDate = ShipDate;
            _ctx.SaveChanges();
        }

        public IEnumerable<Product> GetNewProduct()
        {
            return GetProductsAll().OrderBy(p => p.ProductAddDate).Take(60);
        }

        public IEnumerable<Product> GetNewCategoryProduct(int id)
        {
            return GetProductsAll().OrderBy(p => p.ProductAddDate).Take(9).Where(p=>p.CategoryID==id);
        }

        public IEnumerable<Customer> GetCustomer()
        {
          return  _ctx.Customers.ToList();
        }
    }
}