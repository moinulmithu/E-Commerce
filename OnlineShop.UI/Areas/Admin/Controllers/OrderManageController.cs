using OnlineShop.Domain;
using OnlineShop.UI.Infrastructure;
using OnlineShop.UI.Models;
using OnlineShop.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrderManageController : Controller
    {
        //
        // GET: /Admin/OrderManage/
        Repository _rep = new Repository();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Orders(string status = "Pending")
        {
            
            ViewBag.Status = status;
            List<Order> orders;
            if (status == "ALL")
                orders = _rep.GetOrders().OrderByDescending(o => o.OrderDate).ToList();
            else if (status == "Pending")
                orders = _rep.GetPendingOrders().ToList();
            else
                orders = _rep.GetShippedOrders().ToList();
            var orderviews = new List<OrderView>();
            foreach (var order in orders)
            {
                orderviews.Add(new OrderView
                {
                    OrderID = order.OrderID,
                    CustomerName = order.Customer.FullName,
                    OrderDate = order.OrderDate.ToString("MMM dd,  yyyy HH:mm"),
                    Status = (order.ShipDate == null ? "Pending" : "Shipped"),
                    ShippedDate = (order.ShipDate == null ? "NA" : order.ShipDate.ToString()),
                    OrderValue = order.OrderItems.Sum(i => i.Quantity * i.Product.Price)
                });

            }
            return View(orderviews);
        }
        public ActionResult EditOrder(int id)
        {
            return View(_rep.GetOrderByID(id));
        }
        [HttpPost]
        public ActionResult EditOrder(Order order)
        {
            _rep.UpdateOrder(order.OrderID, order.ShipDate);
            return RedirectToAction("Orders");
        }
        public ActionResult Delete(int id = 0)
        {
            EcommerceContex _ctx = new EcommerceContex();
            Order order = _ctx.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id = 0)
        {
            EcommerceContex _ctx = new EcommerceContex();
            Order order = _ctx.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            _ctx.Orders.Remove(order);
            _ctx.SaveChanges();
            return RedirectToAction("Orders");
        }
    }
}
