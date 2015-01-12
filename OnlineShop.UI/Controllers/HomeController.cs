using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.UI.ViewModel;
using OnlineShop.UI.Models;

namespace OnlineShop.UI.Controllers
{
    public class HomeController : Controller
    {
        Repository _rep = new Repository();
        public ActionResult Index()
        {
            CategiesAndProduct m = new CategiesAndProduct
            {
                Categories = _rep.GetAll(),
                Products = _rep.GetNewProduct()
            };
            return View(m);
        }
        public ActionResult List(int id)
        {
            CategiesAndProduct m = new CategiesAndProduct
            {
                Categories = _rep.GetAll(),
                Products = _rep.GetProductOfCategory(id)
            };
            return View(m);
        }
        public ActionResult Detail(int id)
        {
            CategoriesAndProductDetail m = new CategoriesAndProductDetail
            {
                Categories = _rep.GetAll(),
                Product = _rep.GetProductById(id)
            };
            return View(m);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ProductDetails(int id)
        {            
            var c = _rep.GetProductById(id);
            var m = new ViewProductModel
            {
                ID = c.ProductID,
                Name = c.ProductName,
                Price = c.Price,
                PhotoString = "data:image/png;base64," + Convert.ToBase64String(c.ProductImage),
                sDescription = c.ShortDescription,
                fDescription = c.FullDescription,
                Warranty = c.Warranty,
                Category = c.Category,
                CategoryID = c.CategoryID,
                ProductAddDate = c.ProductAddDate,
                PColor = c.ProductColor,
                Discount = c.Discount,
                products = _rep.GetNewCategoryProduct(c.CategoryID)
            };
            return View(m);
        }
        public ActionResult ProductByCatagory(int id)
        {
           // int _ID = Convert.ToInt32(Request["CategoryID"].ToString());           
            CategiesAndProduct m = new CategiesAndProduct
            {
                Categories = _rep.GetAll(),
                Products = _rep.GetProductOfCategory(id)
            };
            return View(m);
        }
        public ActionResult Service()
        {
            return View();
        }
        public ActionResult Contract()
        {
            return View();
        }

        public ActionResult Prouduc()
        {
            CategiesAndProduct m = new CategiesAndProduct
            {
                Categories = _rep.GetAll(),
                Products = _rep.GetProductsAll()
            };
            return View(m);          
        }

        public ActionResult Returns()
        {
            return View();
        }
    }
}
