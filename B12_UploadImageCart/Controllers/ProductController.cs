using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using B12_UploadImageCart.Models;

namespace B12_UploadImageCart.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            MyDbContext db = new MyDbContext();
            List<Product> pros = db.Products.ToList();
            return View(pros);
        }
    }
}