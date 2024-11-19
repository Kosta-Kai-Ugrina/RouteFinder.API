namespace RouteFinder.API.Model;

public class RouteHttpClient
{
    public static RouteHttpClient Create(string googleApiKey)
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("X-Goog-Api-Key", googleApiKey);
        client.DefaultRequestHeaders.Add("X-Goog-FieldMask", "routes.duration,routes.distanceMeters,routes.polyline.encodedPolyline");
        var routeClient = new RouteHttpClient(client);
        return routeClient;
    }

    private RouteHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<RouteResponse?> RequestRouteDirections(RoutesDirectionsRequest data)
    {
        var dataJson = GoogleApiJsonConverter.Serialize(data);
        var content = new StringContent(
            content: dataJson,
            encoding: Encoding.UTF8,
            mediaType: "application/json");

        var response = await client.PostAsync(uri, content);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var responseContent = await response.Content
            .ReadFromJsonAsync(typeof(RouteResponse)) as RouteResponse;
        responseContent.OptimizedAddressDestinationList = data
            .ToRouteRequest()
            .AddressDestinationList;

        return responseContent;
    }


    public static RoutesDirectionsRequest RequestTemplate
        => new RoutesDirectionsRequest
        {
            TravelMode = RouteTravelMode.Drive,
            RoutingPreference = RoutingPreference.TrafficAware,
            ComputeAlternativeRoutes = false,
            RouteModifiers = new RouteModifiers
            {
                AvoidTolls = false,
                AvoidFerries = false,
                AvoidHighways = false,
            },
            Units = Units.Metric,
            Language = Language.English,
        };

    private readonly HttpClient client;
    private readonly Uri uri = new Uri("https://routes.googleapis.com/directions/v2:computeRoutes");
}
