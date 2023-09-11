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
            List<Employee> employees = GetEmployees();

            // ViewBag.Employees = employees;

            return View(employees);
        }

        public ActionResult Detail(int id) 
        {
            List<Employee> employees = GetEmployees();
            Employee employee = null;
            foreach (var emp in employees)
            {
                if (emp.EmpID == id)
                {
                    employee = emp;
                    break;
                }
            }

            if (employee != null)
            {
                return View(employee);
            }

            return View("NotFound");
        }

        public ActionResult Create() { return View(); }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            emp.EmpID = 10;
            if (emp.Image == null) { emp.Image = "https://i.pravatar.cc/350"; }
            return View("Detail", emp);
        }

        private List<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee {EmpID = 1, EmpName = "Trọng Nghĩa", Gender = "Nam", Image = "https://i.pravatar.cc/400"},
                new Employee {EmpID = 2,EmpName = "Tào Tháo", Gender = "Nam", Image = "https://i.pravatar.cc/300"},
                new Employee {EmpID = 3,EmpName = "Điêu Thuyền", Gender = "Nữ", Image = "https://i.pravatar.cc/200"},
                new Employee {EmpID = 4,EmpName = "Đắc Kỷ", Gender = "Nữ", Image = "https://i.pravatar.cc/150"}
            };
        }
    }
}