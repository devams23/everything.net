using Event_management_Project.Services.DTO.Auth;

namespace Event_management_Project.Services.Interfaces;

public interface IAuthService
{
    Task RegisterAsync(RegisterRequest request, CancellationToken cancellationToken);
    Task<AuthResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken);
    Task<AuthResponse> RefreshAsync(RefreshTokenRequest request, CancellationToken cancellationToken);
    Task LogoutAsync(int userId, CancellationToken cancellationToken);
}
