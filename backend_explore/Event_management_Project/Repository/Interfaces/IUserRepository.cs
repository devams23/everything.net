using Event_management_Project.Repository.Models.Entities;

namespace Event_management_Project.Repository.Interfaces;

public interface IUserRepository
{
    Task<bool> ExistsByUsernameAsync(string username, CancellationToken cancellationToken);
    Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken);
    Task<UserAuthDetail?> GetByUsernameOrEmailAsync(string usernameOrEmail, CancellationToken cancellationToken);
    Task<UserAuthDetail?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<UserAuthDetail?> GetByRefreshTokenHashAsync(string refreshTokenHash, CancellationToken cancellationToken);
    Task AddAsync(UserAuthDetail user, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
