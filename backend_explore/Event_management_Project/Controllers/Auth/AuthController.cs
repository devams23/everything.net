using Event_management_Project.Common;
using Event_management_Project.Services.DTO.Auth;
using Event_management_Project.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Event_management_Project.Controllers.Auth;

[ApiController]
[Route("api/auth")]
[EnableRateLimiting("AuthEndpoints")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    [AllowAnonymous]

    public async Task<IActionResult> Register([FromBody] RegisterRequest request, CancellationToken cancellationToken)
    {
        await _authService.RegisterAsync(request, cancellationToken);
        return Ok(new { message = "User registered successfully. Please login." });
    }

    [HttpPost("login")]
    [AllowAnonymous]
 
    public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        AuthResponse response = await _authService.LoginAsync(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("refresh")]
    [AllowAnonymous]
 
    public async Task<ActionResult<AuthResponse>> Refresh([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        AuthResponse response = await _authService.RefreshAsync(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("logout")]
    [Authorize]
    public async Task<IActionResult> Logout(CancellationToken cancellationToken)
    {
        int userId = User.GetRequiredUserId();
        await _authService.LogoutAsync(userId, cancellationToken);
        return Ok(new { message = "Logged out." });
    }
}
