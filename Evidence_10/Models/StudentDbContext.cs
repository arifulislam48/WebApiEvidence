using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Evidence_10.Models
{
    public class StudentDbContext : IdentityDbContext
    {
        public StudentDbContext() : base("StudentDbContext")
        {

        }
        public DbSet<Student> Student { get; set; }
    }
}