using System.ComponentModel.DataAnnotations;

namespace Event_management_Project.Repository.Models.Entities;

public class Event
{
    public int EventId { get; set; }

    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(2000)]
    public string? Description { get; set; }

    public DateTime StartUtc { get; set; }
    public DateTime EndUtc { get; set; }

    [MaxLength(300)]
    public string Location { get; set; } = string.Empty;

    public int OrganizerId { get; set; }
    public UserAuthDetail? Organizer { get; set; }

    public int Capacity { get; set; }
    public EventStatus Status { get; set; } = EventStatus.Draft;

    public DateTime CreatedUtc { get; set; }
    public DateTime UpdatedUtc { get; set; }

    public ICollection<EventRegistration> Registrations { get; set; } = [];
}
