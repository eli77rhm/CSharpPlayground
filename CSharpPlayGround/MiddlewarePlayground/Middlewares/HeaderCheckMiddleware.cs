namespace MiddlewarePlayground.Middlewares;

public class HeaderCheckMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext ctx)
    {
        Console.WriteLine("HeaderCheckMiddleware started processing request.");
        
        await next(ctx);    

        Console.WriteLine("HeaderCheckMiddleware finished processing request.");
    }
}