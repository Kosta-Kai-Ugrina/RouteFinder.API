using RouteFinder.API.Model;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");
var app = builder.Build();
var googleApiKey = builder.Configuration["GoogleApiKey"];

string? GetGoogleApiKey(string password)
{
    if (password != "PrettyPlease") return null;
    return googleApiKey;
}

async Task<Address[]> FindFastestRoute(
    Address addressStart,
    Address[] addressDestinationList)
{
    return [addressStart, .. addressDestinationList];
}

app.MapGet("/", () => "Hello World!");
app.MapPost("/", FindFastestRoute);
app.MapGet("/google-api-key", GetGoogleApiKey);

app.Run();