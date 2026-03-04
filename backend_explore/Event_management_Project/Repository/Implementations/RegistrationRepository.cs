using Event_management_Project.Common.Models;
using Event_management_Project.Data;
using Event_management_Project.Repository.Interfaces;
using Event_management_Project.Repository.Models.Entities;
using Event_management_Project.Services.DTO.Registration;
using Microsoft.EntityFrameworkCore;

namespace Event_management_Project.Repository.Implementations;

public class RegistrationRepository : IRegistrationRepository
{
    private readonly AppDbContext _context;

    public RegistrationRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<EventRegistration?> GetByEventAndUserAsync(int eventId, int userId, CancellationToken cancellationToken)
    {
        return _context.EventRegistrations.FirstOrDefaultAsync(x => x.EventId == eventId && x.UserId == userId, cancellationToken);
    }

    public Task<int> CountByStatusAsync(int eventId, RegistrationStatus status, CancellationToken cancellationToken)
    {
        return _context.EventRegistrations.CountAsync(x => x.EventId == eventId && x.RegistrationStatus == status, cancellationToken);
    }

    public async Task<int> NextWaitlistPositionAsync(int eventId, CancellationToken cancellationToken)
    {
        int? max = await _context.EventRegistrations
            .Where(x => x.EventId == eventId && x.RegistrationStatus == RegistrationStatus.Waitlisted)
            .MaxAsync(x => x.WaitlistPosition, cancellationToken);

        return (max ?? 0) + 1;
    }

    public Task<EventRegistration?> GetNextWaitlistedAsync(int eventId, CancellationToken cancellationToken)
    {
        return _context.EventRegistrations
            .Where(x => x.EventId == eventId && x.RegistrationStatus == RegistrationStatus.Waitlisted)
            .OrderBy(x => x.WaitlistPosition)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task AddAsync(EventRegistration registration, CancellationToken cancellationToken)
    {
        await _context.EventRegistrations.AddAsync(registration, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<PagedResponse<RegistrationResponse>> GetForEventAsync(int eventId, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        IQueryable<EventRegistration> q = _context.EventRegistrations
            .AsNoTracking()
            .Where(x => x.EventId == eventId)
            .OrderBy(x => x.RegistrationStatus)
            .ThenBy(x => x.WaitlistPosition)
            .ThenBy(x => x.RegisteredUtc);

        int totalCount = await q.CountAsync(cancellationToken);

        List<RegistrationResponse> items = await q
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(x => new RegistrationResponse
            {
                EventId = x.EventId,
                UserId = x.UserId,
                RegisteredUtc = x.RegisteredUtc,
                RegistrationStatus = x.RegistrationStatus,
                WaitlistPosition = x.WaitlistPosition
            })
            .ToListAsync(cancellationToken);

        return new PagedResponse<RegistrationResponse>
        {
            Items = items,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = totalCount,
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
        };
    }

    public async Task<PagedResponse<RegistrationResponse>> GetForUserAsync(int userId, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        IQueryable<EventRegistration> q = _context.EventRegistrations
            .AsNoTracking()
            .Where(x => x.UserId == userId)
            .OrderByDescending(x => x.RegisteredUtc);

        int totalCount = await q.CountAsync(cancellationToken);

        List<RegistrationResponse> items = await q
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(x => new RegistrationResponse
            {
                EventId = x.EventId,
                UserId = x.UserId,
                RegisteredUtc = x.RegisteredUtc,
                RegistrationStatus = x.RegistrationStatus,
                WaitlistPosition = x.WaitlistPosition
            })
            .ToListAsync(cancellationToken);

        return new PagedResponse<RegistrationResponse>
        {
            Items = items,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = totalCount,
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
        };
    }

    public async Task<PagedResponse<RegistrationResponse>> GetAdminRegistrationsAsync(AdminRegistrationQuery query, CancellationToken cancellationToken)
    {
        IQueryable<EventRegistration> q = _context.EventRegistrations.AsNoTracking();

        if (query.EventId.HasValue)
        {
            q = q.Where(x => x.EventId == query.EventId.Value);
        }

        if (query.UserId.HasValue)
        {
            q = q.Where(x => x.UserId == query.UserId.Value);
        }

        if (query.Status.HasValue)
        {
            q = q.Where(x => x.RegistrationStatus == query.Status.Value);
        }

        q = q.OrderByDescending(x => x.RegisteredUtc);

        int totalCount = await q.CountAsync(cancellationToken);

        List<RegistrationResponse> items = await q
            .Skip((query.PageNumber - 1) * query.PageSize)
            .Take(query.PageSize)
            .Select(x => new RegistrationResponse
            {
                EventId = x.EventId,
                UserId = x.UserId,
                RegisteredUtc = x.RegisteredUtc,
                RegistrationStatus = x.RegistrationStatus,
                WaitlistPosition = x.WaitlistPosition
            })
            .ToListAsync(cancellationToken);

        return new PagedResponse<RegistrationResponse>
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
}
