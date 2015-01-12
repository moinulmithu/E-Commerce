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
    public class HomeController : Controller
    {
        //
        // GET: /Admin/Home/

        Repository _rep = new Repository();
        public ActionResult Index(int? page)
        {
            ViewBag.Pager = Pager.Items(100).PerPage(10).Move(page ?? 1).Segment(5).Center();
             SelectList CategoryID = new SelectList(_rep.GetAll(), "CategoryID", "CategoryName");
            ViewBag.CategoryID = CategoryID;
            CategiesAndProduct m = new CategiesAndProduct
            {

                Categories = _rep.GetAll(),
                Products = _rep.GetProductsAll()
            };
            return View(m);
        }

        public ActionResult MemberManage()
        {
            return View(_rep.GetCustomer());
        }
        public ActionResult Delete(int id = 0)
        {
            EcommerceContex _ctx = new EcommerceContex();
            Customer cus = _ctx.Customers.Find(id);
            if (cus == null)
            {
                return HttpNotFound();
            }
            return View(cus);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id = 0)
        {
            EcommerceContex _ctx = new EcommerceContex();
            Customer cus = _ctx.Customers.Find(id);
            if (cus == null)
            {
                return HttpNotFound();
            }

            _ctx.Customers.Remove(cus);
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
