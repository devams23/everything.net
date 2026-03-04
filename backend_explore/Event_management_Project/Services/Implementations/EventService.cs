using Event_management_Project.Common.Exceptions;
using Event_management_Project.Common.Models;
using Event_management_Project.Repository.Interfaces;
using Event_management_Project.Repository.Models.Entities;
using Event_management_Project.Services.DTO.Event;
using Event_management_Project.Services.Interfaces;

namespace Event_management_Project.Services.Implementations;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;

    public EventService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<EventResponse> CreateAsync(int userId, string role, EventCreateRequest request, CancellationToken cancellationToken)
    {
        ValidateEventDates(request.StartUtc, request.EndUtc);

        int organizerId = role == UserRole.Admin.ToString() ? userId : userId;

        Event entity = new()
        {
            Title = request.Title.Trim(),
            Description = request.Description?.Trim(),
            StartUtc = request.StartUtc,
            EndUtc = request.EndUtc,
            Location = request.Location.Trim(),
            OrganizerId = organizerId,
            Capacity = request.Capacity,
            Status = request.Status,
            CreatedUtc = DateTime.UtcNow,
            UpdatedUtc = DateTime.UtcNow
        };

        await _eventRepository.AddAsync(entity, cancellationToken);
        await _eventRepository.SaveChangesAsync(cancellationToken);

        return new EventResponse
        {
            EventId = entity.EventId,
            Title = entity.Title,
            Description = entity.Description,
            StartUtc = entity.StartUtc,
            EndUtc = entity.EndUtc,
            Location = entity.Location,
            OrganizerId = entity.OrganizerId,
            Capacity = entity.Capacity,
            Status = entity.Status
        };
    }

    public async Task<EventResponse> UpdateAsync(int eventId, int userId, string role, EventUpdateRequest request, CancellationToken cancellationToken)
    {
        ValidateEventDates(request.StartUtc, request.EndUtc);

        Event entity = await _eventRepository.GetByIdForUpdateAsync(eventId, cancellationToken)
            ?? throw new ApiException(404, "Event not found.", "event_not_found");

        bool isAdmin = role == UserRole.Admin.ToString();
        if (!isAdmin && entity.OrganizerId != userId)
        {
            throw new ApiException(403, "Organizer can update only owned events.", "forbidden");
        }

        entity.Title = request.Title.Trim();
        entity.Description = request.Description?.Trim();
        entity.StartUtc = request.StartUtc;
        entity.EndUtc = request.EndUtc;
        entity.Location = request.Location.Trim();
        entity.Capacity = request.Capacity;
        entity.Status = request.Status;
        entity.UpdatedUtc = DateTime.UtcNow;

        await _eventRepository.SaveChangesAsync(cancellationToken);

        return new EventResponse
        {
            EventId = entity.EventId,
            Title = entity.Title,
            Description = entity.Description,
            StartUtc = entity.StartUtc,
            EndUtc = entity.EndUtc,
            Location = entity.Location,
            OrganizerId = entity.OrganizerId,
            Capacity = entity.Capacity,
            Status = entity.Status
        };
    }

    public async Task DeleteAsync(int eventId, CancellationToken cancellationToken)
    {
        Event entity = await _eventRepository.GetByIdForUpdateAsync(eventId, cancellationToken)
            ?? throw new ApiException(404, "Event not found.", "event_not_found");

        _eventRepository.Remove(entity);
        await _eventRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task<EventResponse> GetByIdAsync(int eventId, CancellationToken cancellationToken)
    {
        Event entity = await _eventRepository.GetByIdAsync(eventId, cancellationToken)
            ?? throw new ApiException(404, "Event not found.", "event_not_found");

        return new EventResponse
        {
            EventId = entity.EventId,
            Title = entity.Title,
            Description = entity.Description,
            StartUtc = entity.StartUtc,
            EndUtc = entity.EndUtc,
            Location = entity.Location,
            OrganizerId = entity.OrganizerId,
            Capacity = entity.Capacity,
            Status = entity.Status
        };
    }

    public Task<PagedResponse<EventResponse>> GetAllAsync(EventQueryRequest query, CancellationToken cancellationToken)
    {
        return _eventRepository.QueryAsync(query, cancellationToken);
    }

    private static void ValidateEventDates(DateTime startUtc, DateTime endUtc)
    {
        if (endUtc <= startUtc)
        {
            throw new ApiException(400, "EndUtc must be greater than StartUtc.", "invalid_date_range");
        }
    }
}
