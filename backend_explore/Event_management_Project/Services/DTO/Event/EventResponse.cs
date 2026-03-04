using Event_management_Project.Repository.Models.Entities;

namespace Event_management_Project.Services.DTO.Event;

public class EventResponse
{
    public int EventId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime StartUtc { get; set; }
    public DateTime EndUtc { get; set; }
    public string Location { get; set; } = string.Empty;
    public int OrganizerId { get; set; }
    public int Capacity { get; set; }
    public EventStatus Status { get; set; }
    public int ConfirmedCount { get; set; }
    public int WaitlistedCount { get; set; }
}
