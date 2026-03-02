using System.ComponentModel.DataAnnotations;

namespace WebApplication_api.Repository.Models.Auth
{
    public class RegisterRequestModel
    {
        [Required]
        [StringLength(50)]
        public string? Username { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string? Password { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Role { get; set; } = "Customer"; // Admin, Vendor, Customer
    }
}
