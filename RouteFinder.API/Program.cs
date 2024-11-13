using RouteFinder.API.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy => policy
        .AllowAnyOrigin()
        //.WithOrigins(
        //    "http://localhost:3000/", 
        //    "http://localhost:1/",
        //    "https://lively-sky-028740303.5.azurestaticapps.net")
        .AllowAnyHeader()
        .AllowAnyMethod()
    );
});

builder.Configuration.AddJsonFile("appsettings.json");
var app = builder.Build();
var routeSvc = new RoutesService(builder);
app.UseCors();
app.Use(async (HttpContext context, Func<Task> next) =>
{
    var logger = app.Logger;
    var stopwatch = System.Diagnostics.Stopwatch.StartNew();

    // Log the incoming request details
    logger.LogInformation("Incoming request: {method} {url} from {ip}",
        context.Request.Method,
        context.Request.Path,
        context.Connection.RemoteIpAddress);

    // If the request is a POST, read and log the body
    if (context.Request.Method == HttpMethods.Post)
    {
        context.Request.EnableBuffering();
        using var reader = new StreamReader(context.Request.Body, leaveOpen: true);
        var body = await reader.ReadToEndAsync();
        context.Request.Body.Position = 0; // Reset the stream position for the next middleware
        logger.LogInformation("Request body: {body}", body);
    }

    try
    {
        await next();

        logger.LogInformation("Response status: {statusCode} in {elapsedMilliseconds} ms",
            context.Response.StatusCode,
            stopwatch.ElapsedMilliseconds);
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while processing the request. Status: {statusCode}",
            context.Response.StatusCode);
        throw;
    }
});


app.MapGet("/", () => "Hello World 2!");
app.MapPost("/fastest-route", routeSvc.FindFastestRoute);
app.MapGet("/google-api-key", routeSvc.GetGoogleApiKey);
app.MapGet("/test1", routeSvc.TryRoute);
app.MapGet("/test2", routeSvc.TestNearestNeighborOptimizationAlgorithm1);
app.MapGet("/test3", routeSvc.TestNearestNeighborOptimizationAlgorithm2);

app.Run();