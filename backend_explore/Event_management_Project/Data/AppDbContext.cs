
using Microsoft.EntityFrameworkCore;
using Event_management_Project.Repository.Models.Entities;
//using EF_CORE_Final_PROJECT.Config;
//using EF_CORE_Final_PROJECT.Models;
//using Microsoft.EntityFrameworkCore;


namespace WebApplication_api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<UserAuthDetails> UsersAuthDetails { get; set; }


    }
}
