using B12_UploadImageCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B12_UploadImageCart.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Product");
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            if (user != null)
            {
                MyDbContext db = new MyDbContext();
                User myUser = db.Users.Where(u => u.UserName == user.UserName).FirstOrDefault();
                if (myUser != null)
                {
                    if (myUser.Password == user.Password)
                    {
                        HttpCookie authCookie = new HttpCookie("auth", myUser.UserName);
                        HttpCookie roleCookie = new HttpCookie("role", myUser.Role);
                        Response.Cookies.Add(authCookie);
                        Response.Cookies.Add(roleCookie);

                        return RedirectToAction("Index", "Product");
                    }
                }
                ModelState.AddModelError("Password", "Đăng nhập không thành công.");
                return View();
            }
            return View(user);
        }
        public ActionResult Logout()
        {
            HttpCookie authCookie = new HttpCookie("auth");
            authCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(authCookie);

            HttpCookie roleCookie = new HttpCookie("role");
            roleCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(roleCookie);

            return RedirectToAction("Index", "Product");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user, string retypePassword)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (user.Password != retypePassword)
            {
                ModelState.AddModelError("retypePassword", "Passwords do not match.");
                return View();
            }

            MyDbContext db = new MyDbContext();
            User myUser = db.Users.Where(u => u.UserName == user.UserName).FirstOrDefault();
            if (myUser != null)
            {
                ModelState.AddModelError("UserName", "UserName already exist.");
                return View();
            }

            myUser = db.Users.Where(u => u.EmailAddress == user.EmailAddress).FirstOrDefault();
            if (myUser != null)
            {
                ModelState.AddModelError("EmailAddress", "EmailAddress already exist.");
                return View();
            }

            myUser = new User();
            myUser.UserName = user.UserName;
            myUser.Password = user.Password;
            myUser.EmailAddress = user.EmailAddress;
            myUser.Role = "user";
            db.Users.Add(myUser);
            db.SaveChanges();

            return RedirectToAction("Login");
        }
    }
}