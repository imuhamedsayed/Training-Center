using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Configuration;
using TrainingCenter.DAL.Entities;

namespace TrainingCenter.DAL.Database
{
  public  class TrainingCenterDbContext : DbContext
    {

        public TrainingCenterDbContext(DbContextOptions option) : base(option)
        {

        }
        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }
        public DbSet<InstructorCourse> InstructorCourse { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new StudentEntityTypeConfiguration().Configure(modelBuilder.Entity<Student>());
            new InstructorEntityTypeConfiguration().Configure(modelBuilder.Entity<Instructor>());
            new CourseEntityTypeConfiguration().Configure(modelBuilder.Entity<Course>());
            new InstructorCourseEntityTypeConfiguration().Configure(modelBuilder.Entity<InstructorCourse>());
            new StudentCourseEntityTypeConfiguration().Configure(modelBuilder.Entity<StudentCourse>());

        }
    }
}

