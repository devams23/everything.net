using System.ComponentModel.DataAnnotations;

namespace WebApplication_api.Repository.Models.Entities
{
    public class User
    {

        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; } = "Customer"; // Default role: Admin, Vendor, Customer
    }
}
