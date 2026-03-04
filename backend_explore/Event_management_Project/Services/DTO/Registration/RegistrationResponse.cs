using Event_management_Project.Repository.Models.Entities;

namespace Event_management_Project.Services.DTO.Registration;

public class RegistrationResponse
{
    public int EventId { get; set; }
    public int UserId { get; set; }
    public DateTime RegisteredUtc { get; set; }
    public RegistrationStatus RegistrationStatus { get; set; }
    public int? WaitlistPosition { get; set; }
}
