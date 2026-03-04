using Event_management_Project.Common;
using Event_management_Project.Common.Models;
using Event_management_Project.Services.DTO.Registration;
using Event_management_Project.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Event_management_Project.Controllers;

[ApiController]
[Route("api")]
[Authorize]
[EnableRateLimiting("AuthEndpoints")]
public class RegistrationsController : ControllerBase
{
    private readonly IRegistrationService _registrationService;

    public RegistrationsController(IRegistrationService registrationService)
    {
        _registrationService = registrationService;
    }

    [HttpPost("events/{eventId:int}/registrations")]
    [Authorize(Roles = "Attendee")]
    public async Task<ActionResult<RegistrationResponse>> Register(int eventId, CancellationToken cancellationToken)
    {
        int userId = User.GetRequiredUserId();
        RegistrationResponse result = await _registrationService.RegisterAsync(eventId, userId, cancellationToken);
        return Ok(result);
    }

    [HttpDelete("events/{eventId:int}/registrations/me")]
    [Authorize(Roles = "Attendee")]
    public async Task<IActionResult> Cancel(int eventId, CancellationToken cancellationToken)
    {
        int userId = User.GetRequiredUserId();
        await _registrationService.CancelAsync(eventId, userId, cancellationToken);
        return NoContent();
    }

    [HttpGet("events/{eventId:int}/registrations")]
    [Authorize(Roles = "Admin,Organizer")]
    public async Task<ActionResult<PagedResponse<RegistrationResponse>>> GetForEvent(int eventId, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20, CancellationToken cancellationToken = default)
    {
        int userId = User.GetRequiredUserId();
        string role = User.GetRequiredRole();
        PagedResponse<RegistrationResponse> result = await _registrationService.GetForEventAsync(eventId, userId, role, pageNumber, pageSize, cancellationToken);
        return Ok(result);
    }

    [HttpGet("users/me/registrations")]
    [Authorize(Roles = "Attendee")]
    public async Task<ActionResult<PagedResponse<RegistrationResponse>>> GetMine([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20, CancellationToken cancellationToken = default)
    {
        int userId = User.GetRequiredUserId();
        PagedResponse<RegistrationResponse> result = await _registrationService.GetMyRegistrationsAsync(userId, pageNumber, pageSize, cancellationToken);
        return Ok(result);
    }
}
