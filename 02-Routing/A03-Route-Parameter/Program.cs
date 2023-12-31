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

    e.Map(
        "class/{year=2023}",
        async (ctx) =>
        {
            string? year = ctx.Request.RouteValues["year"]?.ToString();
            await ctx.Response.WriteAsync($"Welcome to Class of {year ?? "2023"}");
        }
    );

    e.Map(
        "zoo/{animal}/{animalName?}",
        async ctx =>
        {
            string animal = ctx.Request.RouteValues["animal"]?.ToString()!;
            string? animalName = ctx.Request.RouteValues["animalName"]?.ToString();
            await ctx.Response.WriteAsync($"This is a {animal}\n");
            if (animalName != null)
            {
                await ctx.Response.WriteAsync($"It's name is {animalName}");
            }
        }
    );
});

app.Run(async ctx =>
{
    await ctx.Response.WriteAsync($"Request Received at {ctx.Request.Path}");
});

app.Run();
