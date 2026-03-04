using System.ComponentModel.DataAnnotations;
using Event_management_Project.Repository.Models.Entities;

namespace Event_management_Project.Services.DTO.Event;

public class EventCreateRequest
{
    [Required, StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [StringLength(2000)]
    public string? Description { get; set; }

    [Required]
    public DateTime StartUtc { get; set; }

    [Required]
    public DateTime EndUtc { get; set; }

    [Required, StringLength(300)]
    public string Location { get; set; } = string.Empty;

    [Range(1, 100000)]
    public int Capacity { get; set; }

    public EventStatus Status { get; set; } = EventStatus.Published;
}
