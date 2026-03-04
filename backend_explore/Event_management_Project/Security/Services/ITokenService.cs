using Event_management_Project.Repository.Models.Entities;

namespace Event_management_Project.Security.Services;

public interface ITokenService
{
    (string AccessToken, DateTime ExpiresAtUtc) GenerateAccessToken(UserAuthDetail user);
}
