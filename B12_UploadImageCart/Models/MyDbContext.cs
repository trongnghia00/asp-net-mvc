using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace B12_UploadImageCart.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("CS1") { }

        public DbSet<Product> Products { get; set;}
        public DbSet<Cart> Carts { get; set;}
        public DbSet<User> Users { get; set;}
    }
}