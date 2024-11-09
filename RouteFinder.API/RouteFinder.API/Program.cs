var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/hi", () => "Hi World!");
app.MapGet("/farvel", () => "Goodbye!");

app.Run();
