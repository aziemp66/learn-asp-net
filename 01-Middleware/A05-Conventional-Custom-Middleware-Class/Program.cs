using A05_Conventional_Custom_Middleware_Class.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<ApiRequestMiddleware>();

var app = builder.Build();

app.UseApiRequestMiddleware();

app.UseConventionalMiddleware();

app.MapGet(
    "/",
    async (ctx) =>
    {
        await ctx.Response.WriteAsync("Hemlo guyfdss\n");
    }
);

app.Run();
