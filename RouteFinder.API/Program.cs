using RouteFinder.API.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");
var app = builder.Build();
var routeSvc = new RoutesService(builder);

app.MapGet("/", () => "Hello World 2!");
app.MapPost("/fastest-route", routeSvc.FindFastestRoute);
app.MapPost("/optimal-address-order", routeSvc.FindOptimalAddressOrder);
app.MapGet("/test1", routeSvc.TryRoute);
app.MapGet("/test2", routeSvc.TestNearestNeighborOptimizationAlgorithm1);
app.MapGet("/test3", routeSvc.TestNearestNeighborOptimizationAlgorithm2);

app.Run();