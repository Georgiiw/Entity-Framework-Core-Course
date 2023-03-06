using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Common;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemConfig : DbContext
    {
        public StudentSystemConfig()
        {

        }

        //Loading of the DbContext with DI.
        public StudentSystemConfig(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentsCourses { get; set; }

        //Connection configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbConfig.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        //Fluent API and Entities config
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentCourse>(e => 
            {
                e.HasKey(sc => new { sc.StudentId, sc.CourseId });
            });
        }

    }
}