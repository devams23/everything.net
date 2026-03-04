using System.Security.Cryptography;
using System.Text;

namespace Event_management_Project.Security;

public interface IRefreshTokenService
{
    string GenerateToken();
    string HashToken(string rawToken);
}

public class RefreshTokenService : IRefreshTokenService
{
    public string GenerateToken()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
    }

    public string HashToken(string rawToken)
    {
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(rawToken));
        return Convert.ToBase64String(bytes);
    }
}
