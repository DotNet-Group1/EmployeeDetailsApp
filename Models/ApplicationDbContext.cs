using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeDetailsApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=MyConnection") { }
        public DbSet<Teacher> Teachers { get; set;}
        //public DbSet<Student> students { get; set; }
    }
}