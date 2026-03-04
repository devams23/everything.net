using Event_management_Project.Common.Models;
using Event_management_Project.Repository.Models.Entities;
using Event_management_Project.Services.DTO.Event;

namespace Event_management_Project.Repository.Interfaces;

public interface IEventRepository
{
    Task AddAsync(Event entity, CancellationToken cancellationToken);
    Task<Event?> GetByIdAsync(int eventId, CancellationToken cancellationToken);
    Task<Event?> GetByIdForUpdateAsync(int eventId, CancellationToken cancellationToken);
    Task<bool> ExistsOwnedByAsync(int eventId, int organizerId, CancellationToken cancellationToken);
    Task<PagedResponse<EventResponse>> QueryAsync(EventQueryRequest query, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
    void Remove(Event entity);
}
