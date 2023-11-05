using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using B12_UploadImageCart.Models;

namespace B12_UploadImageCart.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            MyDbContext db = new MyDbContext();
            List<Cart> cart = db.Carts.ToList();
            return View(cart);
        }

        public ActionResult Add(int? id)
        {
            if (id.HasValue)
            {
                MyDbContext db = new MyDbContext();
                Cart cartItem = db.Carts.Where(cart => cart.ProId == id).FirstOrDefault();
                if (cartItem != null)
                {
                    cartItem.Quantity += 1;
                }
                else
                {
                    Cart cart = new Cart();
                    cart.ProId = (int)id;
                    cart.Quantity = 1;
                    db.Carts.Add(cart);
                }
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult UpdateQuantity(int quan = 0, int proid = 0) 
        {
            MyDbContext db = new MyDbContext();
            if (quan > 0)
            {
                Cart cartItem = db.Carts.Where(cart => cart.ProId == proid).FirstOrDefault();
                if (cartItem != null)
                {
                    cartItem.Quantity = quan;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id = 0) 
        {
            MyDbContext db = new MyDbContext();
            if (id > 0)
            {
                Cart cartItem = db.Carts.Where(cart => cart.ProId == id).FirstOrDefault();
                if (cartItem != null)
                {
                    db.Carts.Remove(cartItem);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}