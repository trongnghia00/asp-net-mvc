using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using B10_HTMLHelpers.Models;

namespace B10_HTMLHelpers.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            MyDBContext db = new MyDBContext();
            List<Employee> employees = db.Employees.ToList();
            return View(employees);
        }
    }
}