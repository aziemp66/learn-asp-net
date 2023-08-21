var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(
    async (HttpContext context) =>
    {
        await context.Response.WriteAsJsonAsync(
            new { Message = "Hello World", Sender = "Xi Jin Ping" }
        );
    }
);

app.Run(
    async (HttpContext context) =>
    {
        await context.Response.WriteAsJsonAsync(
            new { Message = "Hello Again", Sender = "Xi Jin Ping" }
        );
    }
);

app.Run();
