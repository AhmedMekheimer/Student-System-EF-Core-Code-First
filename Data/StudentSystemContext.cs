using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using P01_StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data
{
    class StudentSystemContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Students Table
            modelBuilder.Entity<Student>().Property(t => t.StudentId).IsRequired();
            //Name(up to 100 characters, unicode)
            modelBuilder.Entity<Student>().Property(t => t.Name).HasMaxLength(100);
            modelBuilder.Entity<Student>().Property(t => t.Name).IsRequired();
            modelBuilder.Entity<Student>().Property(t => t.RegisteredOn).IsRequired();
            //By default if strings not mentioned to be 'Required' it will be 'Not Required'
            //PhoneNumber (exactly 10 characters, not unicode, not required)
            modelBuilder.Entity<Student>()
            .Property(p => p.PhoneNumber)
            .HasColumnType("varchar");
            modelBuilder.Entity<Student>().Property(t => t.PhoneNumber).HasMaxLength(10);

            //Courses Table
            modelBuilder.Entity<Course>().Property(t => t.CourseId).IsRequired();
            //Name(up to 80 characters, unicode)
            modelBuilder.Entity<Course>().Property(t => t.Name).HasMaxLength(80);
            modelBuilder.Entity<Course>().Property(t => t.Name).IsRequired();
            modelBuilder.Entity<Course>().Property(t => t.StartDate).IsRequired();
            modelBuilder.Entity<Course>().Property(t => t.EndDate).IsRequired();
            modelBuilder.Entity<Course>().Property(t => t.Price).IsRequired();

            //Resources Table
            modelBuilder.Entity<Resource>().Property(t => t.ResourceId).IsRequired();
            modelBuilder.Entity<Resource>().Property(t => t.Name).IsRequired();
            modelBuilder.Entity<Resource>().Property(t => t.Url).IsRequired();
            modelBuilder.Entity<Resource>().Property(t => t.Type).IsRequired();
            modelBuilder.Entity<Resource>().Property(t => t.CourseId).IsRequired();
            modelBuilder.Entity<Resource>().Property(t => t.Name).HasMaxLength(50);
            modelBuilder.Entity<Resource>().Property(t => t.Url).HasColumnType("varchar");

            //Homeworks Table
            modelBuilder.Entity<Homework>().Property(t => t.HomeworkId).IsRequired();
            modelBuilder.Entity<Homework>().Property(t => t.SubmissionTime).IsRequired();
            modelBuilder.Entity<Homework>().Property(t => t.Content).IsRequired();
            modelBuilder.Entity<Homework>().Property(t => t.Type).IsRequired();
            //Content (string, linking to a file, not unicode)
            modelBuilder.Entity<Homework>().Property(t => t.Content).HasColumnType("varchar");

            //StudentCourse Join Table
            modelBuilder.Entity<Student>()
                .HasMany(c => c.Courses)
                .WithMany(s => s.Students)
                .UsingEntity<StudentCourse>();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseSqlServer("Data Source=.;Integrated Security=True;Connect Timeout=30;Trust Server Certificate=True; Initial Catalog=Student System");
        }
    }
}
