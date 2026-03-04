using Event_management_Project.Common.Exceptions;
using Event_management_Project.Common.Models;
using Event_management_Project.Data;
using Event_management_Project.Repository.Interfaces;
using Event_management_Project.Repository.Models.Entities;
using Event_management_Project.Services.DTO.Registration;
using Event_management_Project.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Event_management_Project.Services.Implementations;

public class RegistrationService : IRegistrationService
{
    private readonly AppDbContext _context;
    private readonly IEventRepository _eventRepository;
    private readonly IRegistrationRepository _registrationRepository;

    public RegistrationService(AppDbContext context, IEventRepository eventRepository, IRegistrationRepository registrationRepository)
    {
        _context = context;
        _eventRepository = eventRepository;
        _registrationRepository = registrationRepository;
    }

    public async Task<RegistrationResponse> RegisterAsync(int eventId, int userId, CancellationToken cancellationToken)
    {
        System.Console.WriteLine("registering user:");
        Event ev = await _eventRepository.GetByIdForUpdateAsync(eventId, cancellationToken)
            ?? throw new ApiException(404, "Event not found.", "event_not_found");

        if (ev.Status != EventStatus.Published)
        {
            throw new ApiException(400, "Registrations are allowed only for published events.", "event_not_open");
        }

        EventRegistration? existing = await _registrationRepository.GetByEventAndUserAsync(eventId, userId, cancellationToken);
        if (existing is not null && existing.RegistrationStatus != RegistrationStatus.Cancelled)
        {
            throw new ApiException(409, "Already registered for this event.", "already_registered");
        }

        await using var tx = await _context.Database.BeginTransactionAsync(cancellationToken);

        int confirmed = await _registrationRepository.CountByStatusAsync(eventId, RegistrationStatus.Confirmed, cancellationToken);

        RegistrationStatus status;
        

        if (confirmed < ev.Capacity)
        {
            status = RegistrationStatus.Confirmed;
        }
        else
        {
            status = RegistrationStatus.Waitlisted;

        }

        EventRegistration registration = existing ?? new EventRegistration { EventId = eventId, UserId = userId };
        registration.RegisteredUtc = DateTime.UtcNow;
        registration.RegistrationStatus = status;


        if (existing is null)
        {
            await _registrationRepository.AddAsync(registration, cancellationToken);
        }

        await _registrationRepository.SaveChangesAsync(cancellationToken);
        await tx.CommitAsync(cancellationToken);

        return new RegistrationResponse
        {
            EventId = registration.EventId,
            UserId = registration.UserId,
            RegisteredUtc = registration.RegisteredUtc,
            RegistrationStatus = registration.RegistrationStatus,

        };
    }

    public async Task CancelAsync(int eventId, int userId, CancellationToken cancellationToken)
    {
        EventRegistration registration = await _registrationRepository.GetByEventAndUserAsync(eventId, userId, cancellationToken)
            ?? throw new ApiException(404, "Registration not found.", "registration_not_found");

        if (registration.RegistrationStatus == RegistrationStatus.Cancelled)
        {
            return;
        }

        await using var tx = await _context.Database.BeginTransactionAsync(cancellationToken);

        bool wasConfirmed = registration.RegistrationStatus == RegistrationStatus.Confirmed;
        registration.RegistrationStatus = RegistrationStatus.Cancelled;


        await _registrationRepository.SaveChangesAsync(cancellationToken);
        await tx.CommitAsync(cancellationToken);
    }

    public async Task<PagedResponse<RegistrationResponse>> GetForEventAsync(int eventId, int requesterId, string requesterRole, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        if (requesterRole == UserRole.Organizer.ToString())
        {
            bool owned = await _eventRepository.ExistsOwnedByAsync(eventId, requesterId, cancellationToken);
            if (!owned)
            {
                throw new ApiException(403, "Organizer can only view registrations for owned events.", "forbidden");
            }
        }

        return await _registrationRepository.GetForEventAsync(eventId, pageNumber, pageSize, cancellationToken);
    }

    public Task<PagedResponse<RegistrationResponse>> GetMyRegistrationsAsync(int userId, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        return _registrationRepository.GetForUserAsync(userId, pageNumber, pageSize, cancellationToken);
    }

    public Task<PagedResponse<RegistrationResponse>> GetAdminRegistrationsAsync(AdminRegistrationQuery query, CancellationToken cancellationToken)
    {
        return _registrationRepository.GetAdminRegistrationsAsync(query, cancellationToken);
    }
}
