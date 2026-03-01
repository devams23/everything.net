namespace WebApplication_api.Repository.Models.Auth
{
    public class LoginResponseModel
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public string? AccessToken { get; set; }
        public int? ExpiresIn { get; set; }
    }
}