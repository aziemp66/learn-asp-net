var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(e =>
{
    e.Map(
        "files/{filename}.{extension}",
        async ctx =>
        {
            string? filename = ctx.Request.RouteValues["filename"]?.ToString();
            string? extension = ctx.Request.RouteValues["extension"]?.ToString();
            await ctx.Response.WriteAsync($"In file {filename}.{extension}");
        }
    );

    e.Map(
        "employee/profile/{empName}",
        async ctx =>
        {
            string? employeeName = ctx.Request.RouteValues["empName"]?.ToString();
            await ctx.Response.WriteAsync($"Welcome to {employeeName}'s Company Profile");
        }
    );
});

app.Run(async ctx =>
{
    await ctx.Response.WriteAsync($"Request Received at {ctx.Request.Path}");
});

app.Run();
