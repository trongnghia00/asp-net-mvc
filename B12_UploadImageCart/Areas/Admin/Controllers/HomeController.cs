using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using B12_UploadImageCart.Filters;

namespace B12_UploadImageCart.Areas.Admin.Controllers
{
    [myAuthenFilter]
    [myAuthorFilter]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}