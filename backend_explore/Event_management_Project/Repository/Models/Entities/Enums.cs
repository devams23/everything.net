namespace Event_management_Project.Repository.Models.Entities;

public enum UserRole
{
    Admin = 1,
    Organizer = 2,
    Attendee = 3
}

public enum EventStatus
{
    Draft = 1,
    Published = 2,
    Cancelled = 3,
    Completed = 4
}

public enum RegistrationStatus
{
    Confirmed = 1,
    Waitlisted = 2,
    Cancelled = 3
}
