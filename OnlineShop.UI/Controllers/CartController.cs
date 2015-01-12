using OnlineShop.Domain;
using OnlineShop.UI.Models;
using OnlineShop.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineShop.UI.Controllers
{
  [Authorize]
        public class CartController : Controller
        {
            Repository _rep = new Repository();
            //
            // GET: /Cart/

            public ActionResult Add(int id)
            {
                var carts = _rep.AddToCart(UserID: (int)Membership.GetUser(User.Identity.Name).ProviderUserKey, ProductID: id);
                CartView m = new CartView { CartID = carts.First().CartID, UserID = carts.First().UserId, CartItems = carts.ToList(), Total = carts.Sum(c => c.Product.Price * c.Quantitity) };


                return View("Cart", m);
            }
            [HttpPost]
            public ActionResult Update(Cart cart)
            {
                //Debug.WriteLine(cart.Quantitity);
                _rep.UpadteCart(cart.CartID, cart.Quantitity);
                var carts = _rep.GetCart((int)Membership.GetUser(User.Identity.Name).ProviderUserKey);
                CartView m = new CartView { CartID = carts.First().CartID, UserID = carts.First().UserId, CartItems = carts.ToList(), Total = carts.Sum(c => c.Product.Price * c.Quantitity) };
                return RedirectToAction("Cart");
            }
            public ActionResult Cart()
            {
                var carts = _rep.GetCart((int)Membership.GetUser(User.Identity.Name).ProviderUserKey);
                CartView n =new CartView();    
                
                    CartView m = new CartView { CartID = carts.First().CartID, UserID = carts.First().UserId, CartItems = carts.ToList(), Total = carts.Sum(c => c.Product.Price * c.Quantitity) };
                    return View("Cart", m);

                
            }
        }
    }

