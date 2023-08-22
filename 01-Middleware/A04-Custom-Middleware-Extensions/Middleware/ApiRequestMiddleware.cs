namespace A04_Custom_Middleware_Extesions.Middleware;

public class ApiRequestMiddleware : IMiddleware
{
    async Task IMiddleware.InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await context.Response.WriteAsync("Hello From Custom Middleware 2\n");
        await next(context);
        await context.Response.WriteAsync("Hello Again From Custom Middleware 5\n");
    }
}
