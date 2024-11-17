
namespace RouteFinder.API.Model.RequestData
{
    public class RouteRequest
    {
        [JsonPropertyName("addressStart")]
        public AddressRequest AddressStart { get; set; }

        [JsonPropertyName("addressDestinationList")]
        public List<AddressRequest> AddressDestinationList { get; set; }

        public override string ToString()
        {
            var addressStart = AddressStart.ToString();
            var addressDestinationList = AddressDestinationList
                .Select(addr => addr.ToString());
            var joined = string.Join(
                separator: "\n",
                values: addressDestinationList.Prepend(addressStart));
            
            return joined;
        }

        public RoutesDirectionsRequest ToRoutesDirectionsRequest()
        {
            var routeData = RouteHttpClient.RequestTemplate;
            routeData.Origin = this.AddressStart.ToRouteWayPoint();
            routeData.Intermediates = this.AddressDestinationList
                .SkipLast(1)
                .Select(addr => addr.ToRouteWayPoint());
            routeData.Destination = this.AddressDestinationList
                .Last()
                .ToRouteWayPoint();

            return routeData;
        }
    }
}
