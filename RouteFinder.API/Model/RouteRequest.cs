using System.Text.Json.Serialization;

namespace RouteFinder.API.Model
{
    public class RouteRequest
    {
        [JsonPropertyName("addressStart")]
        public AddressRequest AddressStart { get; set; }

        [JsonPropertyName("addressDestinationList")]
        public List<AddressRequest> AddressDestinationList { get; set; }
    }
}
