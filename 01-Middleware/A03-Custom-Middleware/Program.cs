using A03_Custom_Middleware.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<ApiRequestMiddleware>();

var app = builder.Build();

// Middleware 1
app.Use(
    async (ctx, next) =>
    {
        await ctx.Response.WriteAsync("Hello 1\n");
        await next(ctx);
        await ctx.Response.WriteAsync("Hello 6\n");
    }
);

// Middleware 2
app.UseMiddleware<ApiRequestMiddleware>();

// Middleware 3
app.Use(
    async (ctx, next) =>
    {
        await ctx.Response.WriteAsync("Hello 3\n");
        await next(ctx);
        await ctx.Response.WriteAsync("Hello 4\n");
    }
);

app.MapGet(
    "/",
    async (ctx) =>
    {
        await ctx.Response.WriteAsync("Hemlo World\n");
    }
);

app.Run();
