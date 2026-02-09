using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // Define your DbSets (Tables) here
    public DbSet<Product> Products { get; set; }
}