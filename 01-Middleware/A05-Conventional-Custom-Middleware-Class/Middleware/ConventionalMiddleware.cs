namespace A05_Conventional_Custom_Middleware_Class.Middleware;

class ConventionalMiddleware
{
    private readonly RequestDelegate _next;

    public ConventionalMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (
            context.Request.Query.ContainsKey("first_name")
            && context.Request.Query.ContainsKey("last_name")
        )
        {
            string fullName =
                $"{context.Request.Query["first_name"]} {context.Request.Query["last_name"]}\n";
            await context.Response.WriteAsync(fullName);
        }
        await _next(context);
        if (context.Request.Query.ContainsKey("message"))
        {
            await context.Response.WriteAsync(context.Request.Query["message"]! + "\n");
        }
    }
};
