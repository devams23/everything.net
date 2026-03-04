using System.Text.Json;
using Event_management_Project.Common.Exceptions;

namespace Event_management_Project.Middlewares;

public class GlobalExceptionMiddleware : IMiddleware
{
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(ILogger<GlobalExceptionMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (ApiException ex)
        {
            _logger.LogWarning(ex, "Handled API exception: {ErrorCode}", ex.ErrorCode);
            await WriteProblemAsync(context, ex.StatusCode, ex.ErrorCode, ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception");
            await WriteProblemAsync(context, 500, "server_error", "An unexpected error occurred.");
        }
    }

    private static Task WriteProblemAsync(HttpContext context, int status, string errorCode, string detail)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = status;

        var payload = new
        {
            title = "Request failed",
            status,
            detail,
            errorCode,
            traceId = context.TraceIdentifier
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(payload));
    }
}
