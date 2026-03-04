using Event_management_Project.Common.Models;
using Event_management_Project.Repository.Models.Entities;
using Event_management_Project.Services.DTO.Registration;

namespace Event_management_Project.Repository.Interfaces;

public interface IRegistrationRepository
{
    Task<EventRegistration?> GetByEventAndUserAsync(int eventId, int userId, CancellationToken cancellationToken);
    Task<int> CountByStatusAsync(int eventId, RegistrationStatus status, CancellationToken cancellationToken);
    Task AddAsync(EventRegistration registration, CancellationToken cancellationToken);
    Task<PagedResponse<RegistrationResponse>> GetForEventAsync(int eventId, int pageNumber, int pageSize, CancellationToken cancellationToken);
    Task<PagedResponse<RegistrationResponse>> GetForUserAsync(int userId, int pageNumber, int pageSize, CancellationToken cancellationToken);
    Task<PagedResponse<RegistrationResponse>> GetAdminRegistrationsAsync(AdminRegistrationQuery query, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
