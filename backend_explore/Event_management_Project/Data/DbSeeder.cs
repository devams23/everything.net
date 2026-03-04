using Event_management_Project.Repository.Models.Entities;
using Event_management_Project.Security;
using Microsoft.EntityFrameworkCore;

namespace Event_management_Project.Data;

public static class DbSeeder
{
    public static async Task SeedAdminAndOrganizersAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken = default)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        AppDbContext dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        IPasswordHasher passwordHasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher>();

        await dbContext.Database.MigrateAsync(cancellationToken);

        List<SeedUser> users =
        [
            new("admin", "admin@eventhub.local", "Admin@123", UserRole.Admin, "System", "Admin", "9000000001"),
            new("organizer.ahmedabad", "organizer.ahmedabad@eventhub.local", "Organizer@123", UserRole.Organizer, "Aarav", "Patel", "9000000011"),
            new("organizer.surat", "organizer.surat@eventhub.local", "Organizer@123", UserRole.Organizer, "Isha", "Shah", "9000000012"),
            new("organizer.vadodara", "organizer.vadodara@eventhub.local", "Organizer@123", UserRole.Organizer, "Karan", "Desai", "9000000013")
        ];

        foreach (SeedUser user in users)
        {
            bool exists = await dbContext.UserAuthDetails
                .AnyAsync(x => x.Username == user.Username || x.Email == user.Email, cancellationToken);

            if (exists)
            {
                continue;
            }

            (string hash, string salt) = passwordHasher.HashPassword(user.Password);

            dbContext.UserAuthDetails.Add(new UserAuthDetail
            {
                Username = user.Username,
                Email = user.Email,
                PasswordHash = hash,
                PasswordSalt = salt,
                Role = user.Role,
                UserDetail = new UserDetail
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    ContactNumber = user.ContactNumber
                }
            });
        }

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    private sealed record SeedUser(
        string Username,
        string Email,
        string Password,
        UserRole Role,
        string FirstName,
        string LastName,
        string ContactNumber);
}
