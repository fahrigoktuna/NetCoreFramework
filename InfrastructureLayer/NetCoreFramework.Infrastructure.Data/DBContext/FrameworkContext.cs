using Microsoft.EntityFrameworkCore;
using NetCoreFramework.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreFramework.Infrastructure.Data.DBContext
{
    public class FrameworkContext :DbContext
    {
        public FrameworkContext(DbContextOptions<FrameworkContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("tbl_course");
            modelBuilder.Entity<Enrollment>().ToTable("tbl_enrollment");
            modelBuilder.Entity<Student>().ToTable("tbl_student");
        }
    }
}
