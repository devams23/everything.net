namespace Event_management_Project.Repository.Models.Entities;

public class EventRegistration
{
    public int EventId { get; set; }
    public int UserId { get; set; }

    public Event? Event { get; set; }
    public UserAuthDetail? User { get; set; }

    public DateTime RegisteredUtc { get; set; }
    public RegistrationStatus RegistrationStatus { get; set; }
    public int? WaitlistPosition { get; set; }
}
