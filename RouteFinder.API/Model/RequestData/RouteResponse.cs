
namespace RouteFinder.API.Model.RequestData
{
    public class RouteResponse
    {
        [JsonPropertyName("routes")]
        public List<Routes> Routes { get; set; }
    }

    public class Routes
    {
        [JsonPropertyName("distanceMeters")]
        public int DistanceMeters { get; set; }

        [JsonPropertyName("duration")]
        public string Duration { get; set; }

        [JsonPropertyName("polyline")]
        public Polyline Polyline { get; set; }
    }

    public class Polyline
    {
        [JsonPropertyName("encodedPolyline")]
        public string EncodedPolyline { get; set; }
    }
}
