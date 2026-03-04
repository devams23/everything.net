using Event_management_Project.Repository.Models.Entities;

namespace Event_management_Project.Services.DTO.Event;

public class EventQueryRequest
{
    private const int MaxPageSize = 100;
    private int _pageSize = 20;

    public int PageNumber { get; set; } = 1;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : Math.Max(1, value);
    }

    public DateTime? FromUtc { get; set; }
    public DateTime? ToUtc { get; set; }
    public string? Location { get; set; }
    public EventStatus? Status { get; set; }
    public string SortBy { get; set; } = "startUtc";
    public string SortDir { get; set; } = "asc";
}
