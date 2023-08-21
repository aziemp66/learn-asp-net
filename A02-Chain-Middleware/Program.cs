var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// middleware 1
app.Use(
    async (HttpContext ctx, RequestDelegate next) =>
    {
        await ctx.Response.WriteAsync("Hello China\n");
        await next(ctx);
    }
);

// middleware 2
app.Run(
    async (HttpContext ctx) =>
    {
        await ctx.Response.WriteAsync("Hello World");
    }
);

app.Run();
