var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(e => { });

app.MapGet("/", () => "Hello World!");

app.Run();
