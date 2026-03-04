using Event_management_Project.Config;
using Event_management_Project.Repository.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Event_management_Project.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<UserAuthDetail> UserAuthDetails => Set<UserAuthDetail>();
    public DbSet<UserDetail> UserDetails => Set<UserDetail>();
    public DbSet<Event> Events => Set<Event>();
    public DbSet<EventRegistration> EventRegistrations => Set<EventRegistration>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserDetailConfig());
        modelBuilder.ApplyConfiguration(new EventConfig());
        modelBuilder.ApplyConfiguration(new EventRegistrationConfig());
    }
}
