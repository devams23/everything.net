using Event_management_Project.Common;
using Event_management_Project.Common.Models;
using Event_management_Project.Services.DTO.Event;
using Event_management_Project.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Event_management_Project.Controllers;

[ApiController]
[Route("api/events")]
[Authorize]
[EnableRateLimiting("AuthEndpoints")]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventsController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResponse<EventResponse>>> GetAll([FromQuery] EventQueryRequest request, CancellationToken cancellationToken)
    {
        PagedResponse<EventResponse> result = await _eventService.GetAllAsync(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{eventId:int}")]
    public async Task<ActionResult<EventResponse>> GetById(int eventId, CancellationToken cancellationToken)
    {
        EventResponse result = await _eventService.GetByIdAsync(eventId, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = "Admin,Organizer")]
    public async Task<ActionResult<EventResponse>> Create([FromBody] EventCreateRequest request, CancellationToken cancellationToken)
    {
        Console.WriteLine(request.Status);
        int userId = User.GetRequiredUserId();
        string role = User.GetRequiredRole();
        EventResponse result = await _eventService.CreateAsync(userId, role, request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { eventId = result.EventId }, result);
    }

    [HttpPut("{eventId:int}")]
    [Authorize(Roles = "Admin,Organizer")]
    public async Task<ActionResult<EventResponse>> Update(int eventId, [FromBody] EventUpdateRequest request, CancellationToken cancellationToken)
    {
        int userId = User.GetRequiredUserId();
        string role = User.GetRequiredRole();
        EventResponse result = await _eventService.UpdateAsync(eventId, userId, role, request, cancellationToken);
        return Ok(result);
    }

    [HttpDelete("{eventId:int}")]
    [Authorize(Policy = "OrganizerOrAdmin")]
    public async Task<IActionResult> Delete(int eventId, CancellationToken cancellationToken)
    {
        await _eventService.DeleteAsync(eventId, cancellationToken);
        return NoContent();
    }
}
