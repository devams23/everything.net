using System;
using System.Collections.Generic;
using System.Text;
using EF_CORE_Final_PROJECT.Config;
using EF_CORE_Final_PROJECT.Models;
using Microsoft.EntityFrameworkCore;


namespace EF_CORE_Final_PROJECT.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Trainer> Trainers { get; set; }

        public DbSet<TrainingProgram> TrainingPrograms { get; set; }
        public DbSet<TrainingEnrolledEmployee> TrainingEnrolledEmployees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=EfCore_Project;Trusted_Connection=True;TrustServerCertificate=True;");
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new TrainerConfiguration());
            modelBuilder.ApplyConfiguration(new EnrolledEmployeeConfiguration());
        }

    }
}
