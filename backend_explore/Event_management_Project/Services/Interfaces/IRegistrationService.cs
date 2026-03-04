using Event_management_Project.Common.Models;
using Event_management_Project.Services.DTO.Registration;

namespace Event_management_Project.Services.Interfaces;

public interface IRegistrationService
{
    Task<RegistrationResponse> RegisterAsync(int eventId, int userId, CancellationToken cancellationToken);
    Task CancelAsync(int eventId, int userId, CancellationToken cancellationToken);
    Task<PagedResponse<RegistrationResponse>> GetForEventAsync(int eventId, int requesterId, string requesterRole, int pageNumber, int pageSize, CancellationToken cancellationToken);
    Task<PagedResponse<RegistrationResponse>> GetMyRegistrationsAsync(int userId, int pageNumber, int pageSize, CancellationToken cancellationToken);
    Task<PagedResponse<RegistrationResponse>> GetAdminRegistrationsAsync(AdminRegistrationQuery query, CancellationToken cancellationToken);
}
