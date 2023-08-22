namespace A05_Conventional_Custom_Middleware_Class.Middleware;

public class ApiRequestMiddleware : IMiddleware
{
    async Task IMiddleware.InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await context.Response.WriteAsync("Hello From Custom Middleware 1\n");
        await next(context);
        await context.Response.WriteAsync("Hello Again From Custom Middleware 2\n");
    }
}
