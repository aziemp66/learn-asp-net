var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// middleware 1
app.Use(
    async (ctx, next) =>
    {
        await ctx.Response.WriteAsync("Hello 1\n");
        await next(ctx);
        await ctx.Response.WriteAsync("Hello 4\n");
    }
);

// middleware 2
app.Use(
    async (ctx, next) =>
    {
        await ctx.Response.WriteAsync("Hello 2\n");
        await next(ctx);
        await ctx.Response.WriteAsync("Hello 3\n");
    }
);

// middleware 3
app.Run(
    async (ctx) =>
    {
        await ctx.Response.WriteAsync("Hello World\n");
    }
);

app.Run();
