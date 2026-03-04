using System.ComponentModel.DataAnnotations;

namespace Event_management_Project.Repository.Models.Entities;

public class UserAuthDetail
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string Username { get; set; } = string.Empty;

    [MaxLength(255)]
    public string Email { get; set; } = string.Empty;

    [MaxLength(512)]
    public string PasswordHash { get; set; } = string.Empty;

    [MaxLength(256)]
    public string PasswordSalt { get; set; } = string.Empty;

    public UserRole Role { get; set; } = UserRole.Attendee;


    [MaxLength(512)]
    public string? RefreshTokenHash { get; set; }
    public DateTime? RefreshTokenExpiryUtc { get; set; }
    public DateTime? RefreshTokenCreatedUtc { get; set; }

    public UserDetail? UserDetail { get; set; }
}
