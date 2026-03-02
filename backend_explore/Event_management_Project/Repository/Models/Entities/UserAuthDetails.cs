using System.ComponentModel.DataAnnotations;

namespace .Repository.Models.Entities
{
    public class UserAuthDetails
    {


        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; } = "Customer"; // Default role: Admin, Vendor, Customer
    }
}
