using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using WebApplicationDemo.Models;
using WebApplicationDemo.ViewModels;

namespace WebApplicationDemo.Data
{
    public class ITPQ3Context : DbContext
    {
        public ITPQ3Context(DbContextOptions<ITPQ3Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trainee>()
            .Property(t => t.ImageUrl)
            .IsRequired(false);

            modelBuilder.Entity<Trainee>()
            .Property(t => t.Address)
            .IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<TraineeCourse> TraineeCourses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<WebApplicationDemo.ViewModels.LoginViewModel> LoginViewModel { get; set; } = default!;
        public DbSet<WebApplicationDemo.ViewModels.RegisterViewModel> RegisterViewModel { get; set; } = default!;
    }
}
