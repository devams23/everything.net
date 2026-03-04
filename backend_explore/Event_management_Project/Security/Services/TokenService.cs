using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Event_management_Project.Repository.Models.Entities;
using Event_management_Project.Security.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Event_management_Project.Security.Services;

public class TokenService : ITokenService
{
    private readonly JwtOptions _jwtOptions;

    public TokenService(IOptions<JwtOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;
    }

    public (string AccessToken, DateTime ExpiresAtUtc) GenerateAccessToken(UserAuthDetail user)
    {
        DateTime expiresAtUtc = DateTime.UtcNow.AddMinutes(_jwtOptions.AccessTokenMinutes);
        List<Claim> claims =
        [
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Role, user.Role.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(JwtRegisteredClaimNames.UniqueName, user.Username)
        ];

        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_jwtOptions.Key));
        SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = new(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            expires: expiresAtUtc,
            signingCredentials: creds);
        
        string rawToken = new JwtSecurityTokenHandler().WriteToken(token);
        return (rawToken, expiresAtUtc);
    }
}
