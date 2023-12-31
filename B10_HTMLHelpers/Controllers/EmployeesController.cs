﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using B10_HTMLHelpers.Models;

namespace B10_HTMLHelpers.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index(string sortOrder = "")
        {
            MyDBContext db = new MyDBContext();
            List<Employee> employees = db.Employees.ToList();

            // Thực hiện sắp xếp
            switch (sortOrder)
            {
                case "City":
                    employees = employees.OrderBy(e => e.City).ToList();
                    break;
                case "DepartmentName":
                    employees = employees.OrderBy(e => e.Department.Name).ToList();
                    break;
                case "ID":
                    employees = employees.OrderBy(e => e.Id).ToList();
                    break;
                default:
                    break;
            }

            return View(employees);
        }

        public ActionResult Create() 
        {
            MyDBContext db = new MyDBContext();
            ViewBag.Departments = db.Departments.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                MyDBContext db = new MyDBContext();
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}