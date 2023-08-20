using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B2_Hello.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Index(int id = 0, string name = "") 
        {
            ViewBag.Id = id;
            ViewBag.Name = name;
            return View();    
        }
    }
}