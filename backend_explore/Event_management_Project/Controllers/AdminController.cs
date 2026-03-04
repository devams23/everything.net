using Event_management_Project.Common.Models;
using Event_management_Project.Services.DTO.Registration;
using Event_management_Project.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Event_management_Project.Controllers;

[ApiController]
[Route("api/admin")]
[Authorize(Roles = "Admin")]
[EnableRateLimiting("AuthEndpoints")]
public class AdminController : ControllerBase
{
    private readonly IRegistrationService _registrationService;

    public AdminController(IRegistrationService registrationService)
    {
        _registrationService = registrationService;
    }

    [HttpGet("registrations")]
    public async Task<ActionResult<PagedResponse<RegistrationResponse>>> GetRegistrations([FromQuery] AdminRegistrationQuery query, CancellationToken cancellationToken)
    {
        
        PagedResponse<RegistrationResponse> result = await _registrationService.GetAdminRegistrationsAsync(query, cancellationToken);
        return Ok(result);
    }
}
