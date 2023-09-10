using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using B3_ModelExample.Models;

namespace B3_ModelExample.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee {EmpID = 1, EmpName = "Trọng Nghĩa", Gender = "Nam", Image = "https://i.pravatar.cc/400"},
                new Employee {EmpID = 2,EmpName = "Tào Tháo", Gender = "Nam", Image = "https://i.pravatar.cc/300"},
                new Employee {EmpID = 3,EmpName = "Điêu Thuyền", Gender = "Nữ", Image = "https://i.pravatar.cc/200"},
                new Employee {EmpID = 4,EmpName = "Đắc Kỷ", Gender = "Nữ", Image = "https://i.pravatar.cc/150"}
            };

            ViewBag.Employees = employees;

            return View();
        }
    }
}