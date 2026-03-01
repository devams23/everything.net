
using WebApplication_api.Repository.Models.Entities;
//using EF_CORE_Final_PROJECT.Config;
//using EF_CORE_Final_PROJECT.Models;
//using Microsoft.EntityFrameworkCore;


namespace WebApplication_api.Data
{
    public class AppDbContext
    {
        public List<Product> products;
        public List<User> users;
        public AppDbContext()
        {
            products = new List<Product> {
                    new Product { Id = 1, Name = "Laptop", Description = "A high-performance laptop suitable for gaming and work.", Price = 999.99m, Category = "Electronics" } ,
                    new Product { Id = 2, Name = "Smartphone", Description = "A latest model smartphone with advanced features.", Price = 799.99m, Category = "Electronics" } ,
                    new Product { Id = 3, Name = "Tablet", Description = "A lightweight tablet with a high-resolution display.", Price = 499.99m, Category = "Electronics" } ,
                    new Product { Id = 4, Name = "Headphones", Description = "Noise-cancelling over-ear headphones.", Price = 199.99m, Category = "Electronics" } ,
                    new Product { Id = 5, Name = "Chair", Description = "A comfortable office chair.", Price = 299.99m, Category = "Furniture" } ,

            };
            users = new List<User>
            {
                new User { Id = 1, Name = "Admin User", Username = "admin", Password = "admin123", Email = "admin@example.com", Role = "Admin" },
                new User { Id = 2, Name = "Vendor User", Username = "vendor1", Password = "vendor123", Email = "vendor@example.com", Role = "Vendor" },
                new User { Id = 3, Name = "Customer User", Username = "customer1", Password = "customer123", Email = "customer@example.com", Role = "Customer" }
            };
        }

    }
}
