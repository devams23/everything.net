using System.Security.Cryptography;

namespace Event_management_Project.Security;

public interface IPasswordHasher
{
    (string Hash, string Salt) HashPassword(string password);
    bool VerifyPassword(string password, string hash, string salt);
}

public class PasswordHasher : IPasswordHasher
{
    private const int SaltSize = 16;
    private const int KeySize = 32;
    private const int Iterations = 100_000;

    public (string Hash, string Salt) HashPassword(string password)
    {
        byte[] saltBytes = RandomNumberGenerator.GetBytes(SaltSize);
        byte[] hashBytes = Rfc2898DeriveBytes.Pbkdf2(password, saltBytes, Iterations, HashAlgorithmName.SHA256, KeySize);
        return (Convert.ToBase64String(hashBytes), Convert.ToBase64String(saltBytes));
    }

    public bool VerifyPassword(string password, string hash, string salt)
    {
        byte[] saltBytes = Convert.FromBase64String(salt);
        byte[] computed = Rfc2898DeriveBytes.Pbkdf2(password, saltBytes, Iterations, HashAlgorithmName.SHA256, KeySize);
        byte[] existing = Convert.FromBase64String(hash);
        return CryptographicOperations.FixedTimeEquals(computed, existing);
    }
}
