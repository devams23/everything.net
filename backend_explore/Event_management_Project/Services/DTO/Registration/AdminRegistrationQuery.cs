using Event_management_Project.Repository.Models.Entities;

namespace Event_management_Project.Services.DTO.Registration;

public class AdminRegistrationQuery
{
    private const int MaxPageSize = 100;
    private int _pageSize = 20;

    public int PageNumber { get; set; } = 1;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : Math.Max(1, value);
    }

    public int? EventId { get; set; }
    public int? UserId { get; set; }
    public RegistrationStatus? Status { get; set; }
}
