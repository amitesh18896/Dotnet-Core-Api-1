using Microsoft.EntityFrameworkCore;
using Student.Domin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Student.Domin
{
  public  class StudentDbContext :DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<StudentUser> StudentUsers { get; set; }
    }
}
