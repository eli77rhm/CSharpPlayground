namespace MiddlewarePlayground.Middlewares;

public class HideSensitiveInformationMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext ctx)
    {
        Console.WriteLine("HideSensitiveInformationMiddleware started processing request.");
        
        await next(ctx);    

        Console.WriteLine("HideSensitiveInformationMiddleware finished processing request.");
    }
}