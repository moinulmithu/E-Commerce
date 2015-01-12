using OnlineShop.Domain;
using OnlineShop.UI.Infrastructure;
using OnlineShop.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        EcommerceContex _ctx = new EcommerceContex();
        // GET: /Admin/Category/
        Repository _rep = new Repository();
        public ActionResult Index()
        {
            return View(_rep.GetAll());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            _rep.AddCategory(category);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id = 0)
        {
            EcommerceContex _ctx = new EcommerceContex();
            Category catagory = _ctx.Categories.Find(id);
            if (catagory == null)
            {
                return HttpNotFound();
            }
            return View(catagory);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id = 0)
        {
            EcommerceContex _ctx = new EcommerceContex();
            Category catagory = _ctx.Categories.Find(id);
            if (catagory == null)
            {
                return HttpNotFound();
            }

            _ctx.Categories.Remove(catagory);
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id = 0)
        {
            
            
            Category catagory = _ctx.Categories.Find(id);
            if (catagory == null)
            {
                return HttpNotFound();
            }
           
            return View(catagory);
        }
        [HttpPost]
        public ActionResult Edit(int id ,Category catagory)
        {
            var cat = _ctx.Categories.SingleOrDefault(c => c.CategoryID == id);
            cat.CategoryName = catagory.CategoryName;
            _ctx.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
