using System.Diagnostics;
using System.Security.Claims;

namespace Event_management_Project.Middlewares;

public class RequestLoggingMiddleware : IMiddleware
{
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(ILogger<RequestLoggingMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        Stopwatch sw = Stopwatch.StartNew();
        await next(context);
        sw.Stop();

        string userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "anonymous";
        _logger.LogInformation("{Method} {Path} user={UserId} status={StatusCode} durationMs={Duration}",
            context.Request.Method,
            context.Request.Path,
            userId,
            context.Response.StatusCode,
            sw.ElapsedMilliseconds);
    }
}
