var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async ctx => await ctx.Response.WriteAsync($"In the Root Route"));

app.MapPost("/user", async ctx => await ctx.Response.WriteAsync($"In the User routes"));

// app.Run(async ctx =>
// {
//     await ctx.Response.WriteAsync($"Request Received at {ctx.Request.Path} Endpoint");
// });

app.Run();
