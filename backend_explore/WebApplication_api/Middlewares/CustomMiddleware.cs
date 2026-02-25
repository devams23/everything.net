namespace WebApplication_api.Middlewares
{
    public class CustomMiddleware: IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Custom Middleware: Before next() is called. (Custom Middleware)");
            await next(context);
            //Console.WriteLine("Work that doesn't write to the response. (Custom Middleware)");
            await context.Response.WriteAsync("Custom Middleware: After next() is called. (Custom Middleware)");
        }
    }
}