using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace B10_HTMLHelpers.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() : base("MyconnectString") { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}