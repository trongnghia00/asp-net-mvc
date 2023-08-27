using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B2_LayoutExample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyProfile()
        {
            ViewBag.Title = "Thông tin cá nhân";
            ViewBag.dt = "0898989898";
            ViewBag.id = "profile";
            return View("Contact");
        }

        public ActionResult Family()
        {
            ViewBag.Title = "Thông tin gia đình";
            ViewBag.dt = "0909090909";
            ViewBag.id = "family";
            return View("Contact");
        }
    }
}