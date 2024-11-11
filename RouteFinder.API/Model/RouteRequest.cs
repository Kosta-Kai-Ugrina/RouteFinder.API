using System.Text.Json.Serialization;

namespace RouteFinder.API.Model
{
    public class RouteRequest
    {
        [JsonPropertyName("addressStart")]
        public Address AddressStart { get; set; }

        [JsonPropertyName("addressDestinationList")]
        public List<Address> AddressDestinationList { get; set; }
    }
}
