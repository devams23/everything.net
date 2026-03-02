using System.ComponentModel.DataAnnotations;

namespace WebApplication_api.Repository.Models.Auth
{
    public class LoginRequestModel
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}