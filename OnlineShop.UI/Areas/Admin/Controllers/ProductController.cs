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
    public class ProductController : Controller
    {
           EcommerceContex _ctx = new EcommerceContex();
        // GET: /Admin/Product/
        Repository _rep = new Repository();
        public ActionResult Index()
        {
            return View(_rep.GetProductsAll());
        }
        public ActionResult ProductByCatagory(int id)
        {
 
            return View(_rep.GetProductOfCategory(id));
        }
        public ActionResult ProductByCatagoryID(int? id)
        {
            int _ID = Convert.ToInt32(Request["CategoryID"].ToString());
            return View(_rep.GetProductOfCategory(_ID));
        }
        public ActionResult ProductByID(int id)
        {
            //CategoriesAndProductDetail m = new CategoriesAndProductDetail
            //{
            //    Categories = _rep.GetAll(),
            //    Product = _rep.GetProductById(id)
            //};

            var c = _rep.GetProductById(id);
            var m = new ViewProductModel
            {
                ID = c.ProductID,
                Name = c.ProductName,
                Price = c.Price,
                PhotoString = "data:image/png;base64," + Convert.ToBase64String(c.ProductImage)
            };
            return View(m);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SelectList category= new SelectList(_rep.GetAll(), "CategoryID", "CategoryName");
            ViewBag.category = category;
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct()
        {
            int category = Convert.ToInt32(Request["category"].ToString());           
            string Productname = Request["ProductName"].ToString();
            decimal ProductPrice = Convert.ToDecimal(Request["Price"].ToString());
            //bool Onsale = Convert.ToBoolean(Request["OnSale"].ToString());
            //bool Featured = Convert.ToBoolean(Request["Featured"].ToString());
            string Discount = Request["Discount"].ToString();
            string Warranty = Request["Warranty"].ToString();
            string col = Request["ProductColor"].ToString();
            string fdis = Request["FullDescription"].ToString();
            string sdis = Request["ShortDescription"].ToString();
            //try{
           
                HttpPostedFileBase file = Request.Files[0];
                string mt = file.ContentType;
                byte[] imageSize = new byte[file.ContentLength];
                file.InputStream.Read(imageSize, 0, (int)file.ContentLength);
                Product newProduct = new Product()
                {
                    CategoryID = category,
                    Price= ProductPrice,
                    ProductName= Productname,
                    ImageMT=mt,
                    ProductImage = imageSize,
                    Warranty= Warranty,
                    ProductColor = col,
                    //OnSale = Onsale,
                    //Featured = Featured,
                    Discount = Discount,
                    FullDescription= fdis,
                    ShortDescription = sdis,
                   ProductAddDate = DateTime.Now.Date 
                };
                _rep.AddProduct(newProduct);
                return RedirectToAction("/");
            // }
            //catch (Exception e)
            //{
            //    ModelState.AddModelError("uploadError", e);
            //}
            //return View();
        }

        public ActionResult Edit(int id = 0)
        {
            Product product = _ctx.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        //
        // POST: /ranu/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            var dbProduct = _ctx.Products.SingleOrDefault(p=>p.ProductID==id);
                   dbProduct.CategoryID = product.CategoryID;
                    dbProduct.Price= product.Price;
                    dbProduct.ProductName= product.ProductName;
                   // dbProduct.ImageMT=mt,
                    //dbProduct.ProductImage = imageSize,
                    dbProduct.Warranty= product.Warranty;
                    dbProduct.ProductColor = product.ProductColor;
                    dbProduct.Discount = product.Discount ;
                    dbProduct.FullDescription = product.FullDescription;
                    dbProduct.ShortDescription = product.ShortDescription;
                   dbProduct.ProductAddDate = product.ProductAddDate;
                   _ctx.SaveChanges();            
            return RedirectToAction("/");
        }

        public ActionResult Delete(int id = 0)
        {
       
            Product product = _ctx.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id = 0)
        {
        
            Product product = _ctx.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            _ctx.Products.Remove(product);
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
