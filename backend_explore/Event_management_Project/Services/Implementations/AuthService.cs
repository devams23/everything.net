using Event_management_Project.Common.Exceptions;
using Event_management_Project.Repository.Interfaces;
using Event_management_Project.Repository.Models.Entities;
using Event_management_Project.Security;
using Event_management_Project.Security.Options;
using Event_management_Project.Security.Services;
using Event_management_Project.Services.DTO.Auth;
using Event_management_Project.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace Event_management_Project.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IRefreshTokenService _refreshTokenService;
    private readonly ITokenService _tokenService;
    private readonly JwtOptions _jwtOptions;

    public AuthService(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IRefreshTokenService refreshTokenService,
        ITokenService tokenService,
        IOptions<JwtOptions> jwtOptions
       )
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _refreshTokenService = refreshTokenService;
        _tokenService = tokenService;
        _jwtOptions = jwtOptions.Value;

    }

    public async Task RegisterAsync(RegisterRequest request, CancellationToken cancellationToken)
    {
        if (await _userRepository.ExistsByUsernameAsync(request.Username, cancellationToken))
        {
            throw new ApiException(409, "Username already exists.", "duplicate_username");
        }

        if (await _userRepository.ExistsByEmailAsync(request.Email, cancellationToken))
        {
            throw new ApiException(409, "Email already exists.", "duplicate_email");
        }

        (string hash, string salt) = _passwordHasher.HashPassword(request.Password);

        UserAuthDetail user = new()
        {
            Username = request.Username.Trim(),
            Email = request.Email.Trim().ToLowerInvariant(),
            PasswordHash = hash,
            PasswordSalt = salt,
            Role = UserRole.Attendee,
            UserDetail = new UserDetail
            {
                FirstName = request.FirstName.Trim(),
                LastName = request.LastName.Trim(),
                ContactNumber = request.ContactNumber?.Trim()
            }
        };

        await _userRepository.AddAsync(user, cancellationToken);
        await _userRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task<AuthResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken)
    {
        UserAuthDetail user = await _userRepository.GetByUsernameOrEmailAsync(request.UsernameOrEmail.Trim(), cancellationToken)
            ?? throw new ApiException(401, "Invalid credentials.", "invalid_credentials");


        if (!_passwordHasher.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt))
        {

            throw new ApiException(401, "Invalid credentials.", "invalid_credentials");
        }



        (string refreshToken, _, _) = CreateAndStoreRefreshToken(user);
        (string accessToken, DateTime accessExpiry) = _tokenService.GenerateAccessToken(user);

        await _userRepository.SaveChangesAsync(cancellationToken);

        return BuildAuthResponse(user, accessToken, accessExpiry, refreshToken);
    }

    public async Task<AuthResponse> RefreshAsync(RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        string requestedHash = _refreshTokenService.HashToken(request.RefreshToken.Trim());

        UserAuthDetail user = await _userRepository.GetByRefreshTokenHashAsync(requestedHash, cancellationToken)
            ?? throw new ApiException(401, "Invalid refresh token.", "invalid_refresh_token");

        if (user.RefreshTokenExpiryUtc is null || user.RefreshTokenExpiryUtc <= DateTime.UtcNow)
        {
            throw new ApiException(401, "Refresh token expired.", "refresh_expired");
        }

        (string refreshToken, _, _) = CreateAndStoreRefreshToken(user);
        (string accessToken, DateTime accessExpiry) = _tokenService.GenerateAccessToken(user);

        await _userRepository.SaveChangesAsync(cancellationToken);

        return BuildAuthResponse(user, accessToken, accessExpiry, refreshToken);
    }

    public async Task LogoutAsync(int userId, CancellationToken cancellationToken)
    {
        UserAuthDetail user = await _userRepository.GetByIdAsync(userId, cancellationToken)
            ?? throw new ApiException(404, "User not found.", "user_not_found");

        user.RefreshTokenHash = null;
        user.RefreshTokenCreatedUtc = null;
        user.RefreshTokenExpiryUtc = null;

        await _userRepository.SaveChangesAsync(cancellationToken);
    }

    private (string Raw, string Hash, DateTime Expiry) CreateAndStoreRefreshToken(UserAuthDetail user)
    {
        string rawRefresh = _refreshTokenService.GenerateToken();
        string hashedRefresh = _refreshTokenService.HashToken(rawRefresh);
        DateTime refreshExpiry = DateTime.UtcNow.AddDays(_jwtOptions.RefreshTokenDays);

        user.RefreshTokenHash = hashedRefresh;
        user.RefreshTokenCreatedUtc = DateTime.UtcNow;
        user.RefreshTokenExpiryUtc = refreshExpiry;

        return (rawRefresh, hashedRefresh, refreshExpiry);
    }

    private static AuthResponse BuildAuthResponse(UserAuthDetail user, string accessToken, DateTime accessExpiry, string refreshToken)
    {
        return new AuthResponse
        {
            UserId = user.Id,
            Username = user.Username,
            Email = user.Email,
            Role = user.Role.ToString(),
            AccessToken = accessToken,
            ExpiresInSeconds = (int)Math.Max(1, (accessExpiry - DateTime.UtcNow).TotalSeconds),
            RefreshToken = refreshToken
        };
    }
}
