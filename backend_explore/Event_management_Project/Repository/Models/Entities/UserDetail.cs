using System.ComponentModel.DataAnnotations;

namespace Event_management_Project.Repository.Models.Entities;

public class UserDetail
{
    public int UserDetailId { get; set; }
    public UserAuthDetail? UserAuthDetail { get; set; }

    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    [MaxLength(20)]
    public string? ContactNumber { get; set; }
}
