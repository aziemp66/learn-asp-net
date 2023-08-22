var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseWhen(
    (ctx) => ctx.Request.Query.ContainsKey("auth"),
    app =>
    {
        app.Use(
            async (ctx, next) =>
            {
                await ctx.Response.WriteAsync($"Welcome Back {ctx.Request.Query["auth"]}\n");
                await next(ctx);
            }
        );
    }
);

app.MapGet("/", () => "Hello World!");

app.Run();
