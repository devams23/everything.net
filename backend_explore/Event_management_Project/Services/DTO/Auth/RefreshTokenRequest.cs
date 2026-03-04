using System.ComponentModel.DataAnnotations;

namespace Event_management_Project.Services.DTO.Auth;

public class RefreshTokenRequest
{
    [Required]
    public string RefreshToken { get; set; } = string.Empty;
}
