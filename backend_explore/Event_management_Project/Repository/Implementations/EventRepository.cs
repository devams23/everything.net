using Event_management_Project.Common.Models;
using Event_management_Project.Data;
using Event_management_Project.Repository.Interfaces;
using Event_management_Project.Repository.Models.Entities;
using Event_management_Project.Services.DTO.Event;
using Microsoft.EntityFrameworkCore;

namespace Event_management_Project.Repository.Implementations;

public class EventRepository : IEventRepository
{
    private readonly AppDbContext _context;

    public EventRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task AddAsync(Event entity, CancellationToken cancellationToken)
    {
        return _context.Events.AddAsync(entity, cancellationToken).AsTask();
    }

    public Task<Event?> GetByIdAsync(int eventId, CancellationToken cancellationToken)
    {
        return _context.Events.AsNoTracking().FirstOrDefaultAsync(e => e.EventId == eventId, cancellationToken);
    }

    public Task<Event?> GetByIdForUpdateAsync(int eventId, CancellationToken cancellationToken)
    {
        return _context.Events.FirstOrDefaultAsync(e => e.EventId == eventId, cancellationToken);
    }

    public Task<bool> ExistsOwnedByAsync(int eventId, int organizerId, CancellationToken cancellationToken)
    {
        return _context.Events.AnyAsync(e => e.EventId == eventId && e.OrganizerId == organizerId, cancellationToken);
    }

    public async Task<PagedResponse<EventResponse>> QueryAsync(EventQueryRequest query, CancellationToken cancellationToken)
    {
        IQueryable<Event> q = _context.Events.AsNoTracking();

        if (query.FromUtc.HasValue)
        {
            q = q.Where(e => e.StartUtc >= query.FromUtc.Value);
        }

        if (query.ToUtc.HasValue)
        {
            q = q.Where(e => e.StartUtc <= query.ToUtc.Value);
        }

        if (!string.IsNullOrWhiteSpace(query.Location))
        {
            q = q.Where(e => EF.Functions.Like(e.Location, $"%{query.Location.Trim()}%"));
        }

        if (query.Status.HasValue)
        {
            q = q.Where(e => e.Status == query.Status.Value);
        }

        bool desc = string.Equals(query.SortDir, "desc", StringComparison.OrdinalIgnoreCase);
        q = query.SortBy.ToLowerInvariant() switch
        {
            "title" => desc ? q.OrderByDescending(e => e.Title) : q.OrderBy(e => e.Title),
            "createdutc" => desc ? q.OrderByDescending(e => e.CreatedUtc) : q.OrderBy(e => e.CreatedUtc),
            _ => desc ? q.OrderByDescending(e => e.StartUtc) : q.OrderBy(e => e.StartUtc)
        };

        int totalCount = await q.CountAsync(cancellationToken);

        List<EventResponse> items = await q
            .Skip((query.PageNumber - 1) * query.PageSize)
            .Take(query.PageSize)
            .Select(e => new EventResponse
            {
                EventId = e.EventId,
                Title = e.Title,
                Description = e.Description,
                StartUtc = e.StartUtc,
                EndUtc = e.EndUtc,
                Location = e.Location,
                OrganizerId = e.OrganizerId,
                Capacity = e.Capacity,
                Status = e.Status,
                ConfirmedCount = e.Registrations.Count(r => r.RegistrationStatus == RegistrationStatus.Confirmed),
                WaitlistedCount = e.Registrations.Count(r => r.RegistrationStatus == RegistrationStatus.Waitlisted)
            })
            .ToListAsync(cancellationToken);

        return new PagedResponse<EventResponse>
        {
            Items = items,
            PageNumber = query.PageNumber,
            PageSize = query.PageSize,
            TotalCount = totalCount,
            TotalPages = (int)Math.Ceiling(totalCount / (double)query.PageSize)
        };
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }

    public void Remove(Event entity)
    {
        _context.Events.Remove(entity);
    }
}
