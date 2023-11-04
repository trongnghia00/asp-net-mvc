﻿using System;
using System.Collections.Generic;
using System.IO;
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

        public ActionResult Add() { return View(); }

        [HttpPost]
        public ActionResult Add(Product product, HttpPostedFileBase imageFile) 
        { 
            if (ModelState.IsValid)
            {
                MyDbContext myDbContext = new MyDbContext();

                if (imageFile !=  null && imageFile.ContentLength > 0)
                {
                    // Kiểm tra kích thước file
                    if (imageFile.ContentLength > 2000000)
                    {
                        ModelState.AddModelError("Image", "Kích thước file không được lớn hơn 2MB.");
                        return View();
                    }

                    // Kiểm tra loại tập tin
                    var allowedExtensions = new[] { ".jpg", ".png" };
                    var fileExtension = Path.GetExtension(imageFile.FileName).ToLower();
                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        ModelState.AddModelError("Image", "Chỉ chấp nhận hình ảnh định dạng jpg hoặc png.");
                        return View();
                    }
                    // Lưu thông tin vào CSDL trừ Image
                    product.Image = "";
                    myDbContext.Products.Add(product);
                    myDbContext.SaveChanges();

                    // Truy vấn product mới thêm vào
                    myDbContext = new MyDbContext();
                    Product pro = myDbContext.Products.ToList().Last();

                    // Tiếp tục lưu hình ảnh và thông tin sản phẩm vào cơ sở dữ liệu
                    var fileName = pro.ProId.ToString() + fileExtension;
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    imageFile.SaveAs(path);
                    
                    pro.Image = fileName;
                    myDbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    product.Image = "";
                    myDbContext.Products.Add(product);
                    myDbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View();
            }
        }
    }
}