namespace A05_Conventional_Custom_Middleware_Class.Middleware;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseApiRequestMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ApiRequestMiddleware>();
    }

    public static IApplicationBuilder UseConventionalMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ConventionalMiddleware>();
    }
}
