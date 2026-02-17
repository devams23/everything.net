using EF_CORE.DAY_1.MODELS;
using Microsoft.EntityFrameworkCore;


namespace EF_CORE.DAY_1.DATA
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        // Configure the database connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Replace "YourServerName" and "EfCoreDemoDB" with your actual server and database names
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=EfCoreDemoDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                // fluent api usage
        }
    }
}
