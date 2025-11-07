using System.Diagnostics;

namespace MiddlewarePlayground.Middlewares;

public class RequestLoggingMiddleware(RequestDelegate _next)
{
    public async Task InvokeAsync(HttpContext ctx)
    {
       Console.WriteLine("RequestLoggingMiddleware started processing request.");
        
        await _next(ctx);    

        Console.WriteLine("RequestLoggingMiddleware finished processing request.");
    }
}