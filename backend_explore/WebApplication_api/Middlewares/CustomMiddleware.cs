using System.Security.Claims;

namespace WebApplication_api.Middlewares
{
    public class CustomMiddleware : IMiddleware
    {
        private readonly ILogger<CustomMiddleware> _logger;

        public CustomMiddleware(ILogger<CustomMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // Log incoming request
            _logger.LogInformation($"[REQUEST] {context.Request.Method} {context.Request.Path}");

            // Log user information if authenticated
            try
            {
                await next(context);

                var username = context.User.FindFirstValue(ClaimTypes.Name);
                Console.WriteLine("hello im in custom middlware");
                if (username != null)
                {
                    _logger.LogInformation($"[AUTH] Authenticated user: {username}");
                }
                _logger.LogInformation($"[RESPONSE] Status Code: {context.Response.StatusCode}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"[ERROR] Exception in middleware: {ex.Message}");
                throw;
            }
        }
    }
}
