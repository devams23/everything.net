using System;
using System.Collections.Generic;
using System.Text;
using WebApplication_api.Repository.Models;
//using EF_CORE_Final_PROJECT.Config;
//using EF_CORE_Final_PROJECT.Models;
//using Microsoft.EntityFrameworkCore;


namespace EF_CORE_Final_PROJECT.Data
{
    public class AppDbContext
    {
        public List<Product> products;
        public AppDbContext()
        {
            products = new List<Product> { 
                    new Product { Id = 1, Name = "Laptop", Description = "A high-performance laptop suitable for gaming and work.", Price = 999.99m, Category = "Electronics" } , 
                    new Product { Id = 2, Name = "Smartphone", Description = "A latest model smartphone with advanced features.", Price = 799.99m, Category = "Electronics" } ,
                    new Product { Id = 3, Name = "Tablet", Description = "A lightweight tablet with a high-resolution display.", Price = 499.99m, Category = "Electronics" } , 
                    new Product { Id = 4, Name = "Headphones", Description = "Noise-cancelling over-ear headphones.", Price = 199.99m, Category = "Electronics" } , 
                    new Product { Id = 5, Name = "Chair", Description = "A comfortable office chair.", Price = 299.99m, Category = "Furniture" } ,

            };
        }

    }
}
