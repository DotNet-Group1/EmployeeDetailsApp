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
        public DbSet<Teacher> tblTeachers { get; set;}
        //public DbSet<Student> students { get; set; }
    }
}