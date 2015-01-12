using OnlineShop.Domain;
using OnlineShop.UI.Models;
using OnlineShop.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineShop.UI.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        Repository _rep = new Repository();
        //
        // GET: /Order/

        public ActionResult Checkout()
        {
            var carts = _rep.GetCart((int)Membership.GetUser(User.Identity.Name).ProviderUserKey);
            Customer cust = _rep.GetCustomerByKey(carts.First().UserId);
           // Debug.WriteLine(cust.CustomerID);
            var m = new PreOrderView
            {
                Cart = new CartView { CartID = carts.First().CartID, UserID = carts.First().UserId, CartItems = carts.ToList(), Total = carts.Sum(c => c.Product.Price * c.Quantitity) },
                CustomerDetail = cust
            };
            return View(m);
        }
        [HttpPost]
        public ActionResult Checkout(Customer customer)
        {
            var carts = _rep.GetCart(customer.UserID);
            var m = new PreOrderView
            {
                Cart = new CartView { CartID = carts.First().CartID, UserID = (int)customer.UserID, CartItems = carts.ToList(), Total = carts.Sum(c => c.Product.Price * c.Quantitity) },
                CustomerDetail = customer
            };
            if (string.IsNullOrEmpty(customer.FullName))
            {
                ModelState.AddModelError("FullName", "Full Name Required!");
            }
            if (string.IsNullOrEmpty(customer.Address))
            {
                ModelState.AddModelError("Address", "Address Required!");
            }
            if (string.IsNullOrEmpty(customer.CcNumber))
            {
                ModelState.AddModelError("CcNumber", "CC Numer Required!");
            }
            if (!ModelState.IsValid)
            {




                return View(m);

            }
            _rep.UpdateCustomer(customer);
            return View(m);
        }
        public ActionResult DoCheckout()
        {
            Customer cust = _rep.GetCustomerByKey((int)Membership.GetUser(User.Identity.Name).ProviderUserKey);
            if (string.IsNullOrEmpty(cust.Address) || string.IsNullOrEmpty(cust.FullName) || string.IsNullOrEmpty(cust.CcNumber))
                return RedirectToAction("Checkout");
            _rep.CreateOrder((int)Membership.GetUser(User.Identity.Name).ProviderUserKey);
            return View("Confirm");
        }

    }
}

