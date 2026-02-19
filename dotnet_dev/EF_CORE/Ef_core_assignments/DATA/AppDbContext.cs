using EF_CORE.DAY_1.MODELS;
using Microsoft.EntityFrameworkCore;


namespace EF_CORE.DAY_1.DATA
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Batch> Batches { get; set; }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }


        // Configure the database connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=EfCoreDemoDB_Day2;Trusted_Connection=True;TrustServerCertificate=True;")
                .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trainer>(b =>
            {
                b.HasData(
                    new Trainer { Id = 1, Name = "Hemant Chauhan" , ExperienceYears = 20 },
                    new Trainer {Id = 2,  Name = "Aman Tiwari" , ExperienceYears = 15 },
                    new Trainer { Id=3, Name = "Jaimin Patel" , ExperienceYears = 10 }
                    );
            });

            modelBuilder.Entity<Course>(b =>
            {
                b.HasData(
                    new Course { Id = 1,  Title = ".NET" , DurationInMonths = 6, Fees = 10000 },
                    new Course { Id = 2, Title = "Angular" , DurationInMonths = 3, Fees = 9000 },
                    new Course { Id=3 , Title = "React.js" , DurationInMonths = 4, Fees = 8000 }
              
                    );
            });

            modelBuilder.Entity<Student>(b =>
            {
                b.HasData(
                    new Student { Id=1, Name = "Devam" , Email = "devam@chill.com" },
                    new Student {Id=2, Name = "Krunal" , Email = "krunal@chill.com" },
                    new Student { Id = 3, Name = "Niken" , Email = "niken@chill.com" },
                    new Student { Id = 4, Name = "Aayush" , Email = "Aayush90@chill.com" }

                    );
            });
            // Seed Authors
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    AuthorId = 1,
                    FirstName = "George",
                    LastName = "Orwell"
                },
                new Author
                {
                    AuthorId = 2,
                    FirstName = "Jane",
                    LastName = "Austen"
                }
            );

            // Seed Books
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 1,
                    Title = "1984",
                    AuthorId = 1
                },
                new Book
                {
                    BookId = 2,
                    Title = "Animal Farm",
                    AuthorId = 1
                },
                new Book
                {
                    BookId = 3,
                    Title = "Pride and Prejudice",
                    AuthorId = 2
                }
            );

        }
    }
}
