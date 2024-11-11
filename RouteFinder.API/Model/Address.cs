using System.Text.Json.Serialization;

namespace RouteFinder.API.Model
{
    public class Address
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("latitude")]
        public double? Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double? Longitude { get; set; }
    }
}
