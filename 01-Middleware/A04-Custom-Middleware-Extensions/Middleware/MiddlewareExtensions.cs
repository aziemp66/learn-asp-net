namespace A04_Custom_Middleware_Extesions.Middleware;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseApiRequestMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ApiRequestMiddleware>();
    }
}
