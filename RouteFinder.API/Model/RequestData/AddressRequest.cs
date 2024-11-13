using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Routes.Common;
using System.Text.Json.Serialization;

namespace RouteFinder.API.Model.RequestData
{
    public class AddressRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("latitude")]
        public double? Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double? Longitude { get; set; }

        public override string ToString()
            => $"{Name}-{{{Latitude} | {Longitude}}}";

        public RouteWayPoint ToRouteWayPoint()
            => new()
            {
                Address = this.Name,
                Location = new RouteLocation
                {
                    LatLng = new LatLng
                    {
                        Latitude = (double)this.Latitude,
                        Longitude = (double)this.Longitude,
                    }
                }
            };
    }
}
