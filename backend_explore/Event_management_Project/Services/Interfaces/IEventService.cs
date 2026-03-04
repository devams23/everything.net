using Event_management_Project.Common.Models;
using Event_management_Project.Services.DTO.Event;

namespace Event_management_Project.Services.Interfaces;

public interface IEventService
{
    Task<EventResponse> CreateAsync(int userId, string role, EventCreateRequest request, CancellationToken cancellationToken);
    Task<EventResponse> UpdateAsync(int eventId, int userId, string role, EventUpdateRequest request, CancellationToken cancellationToken);
    Task DeleteAsync(int eventId, CancellationToken cancellationToken);
    Task<EventResponse> GetByIdAsync(int eventId, CancellationToken cancellationToken);
    Task<PagedResponse<EventResponse>> GetAllAsync(EventQueryRequest query, CancellationToken cancellationToken);
}
