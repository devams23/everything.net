using Event_management_Project.Data;
using Event_management_Project.Repository.Interfaces;
using Event_management_Project.Repository.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Event_management_Project.Repository.Implementations;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<bool> ExistsByUsernameAsync(string username, CancellationToken cancellationToken)
    {
        return _context.UserAuthDetails.AnyAsync(x => x.Username == username, cancellationToken);
    }

    public Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return _context.UserAuthDetails.AnyAsync(x => x.Email == email, cancellationToken);
    }

    public Task<UserAuthDetail?> GetByUsernameOrEmailAsync(string usernameOrEmail, CancellationToken cancellationToken)
    {
        return _context.UserAuthDetails
            .Include(x => x.UserDetail)
            .FirstOrDefaultAsync(x => x.Username == usernameOrEmail || x.Email == usernameOrEmail, cancellationToken);
    }

    public Task<UserAuthDetail?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return _context.UserAuthDetails
            .Include(x => x.UserDetail)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public Task<UserAuthDetail?> GetByRefreshTokenHashAsync(string refreshTokenHash, CancellationToken cancellationToken)
    {
        return _context.UserAuthDetails
            .Include(x => x.UserDetail)
            .FirstOrDefaultAsync(x => x.RefreshTokenHash == refreshTokenHash, cancellationToken);
    }

    public Task AddAsync(UserAuthDetail user, CancellationToken cancellationToken)
    {
        return _context.UserAuthDetails.AddAsync(user, cancellationToken).AsTask();
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}
