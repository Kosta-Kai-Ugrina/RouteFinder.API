using RouteFinder.API.Model;
using RouteFinder.API.Utils;
using RouteFinder.API.Utils.Serialization;
using GoogleRoute = GoogleApi.Entities.Maps.Directions.Response.Route;

namespace RouteFinder.API.Service
{
    public class RoutesService
    {
        public async Task<string> TryRoute()
        {
            var routeData = RouteExamples.Example01();
            var responseContent = await client.RequestRouteDirections(routeData);
            return responseContent;
        }

        public RoutesService(WebApplicationBuilder builder)
        {
            this.googleApiKey = builder.Configuration["GoogleApiKey"];
            this.client = new RouteHttpClient(RouteHttpClient.CreateHttpClientTemplate(googleApiKey));
        }

        public string? GetGoogleApiKey(string password)
        {
            if (password != "PrettyPlease") return null;
            return googleApiKey;
        }

        public async Task<List<AddressRequest>> FindFastestRoute(
            RouteRequest routeRequest)
        {
            var addressStart = routeRequest.AddressStart;
            var addressDestinationList = routeRequest.AddressDestinationList;

            return [addressStart, .. addressDestinationList];
        }

        private readonly string googleApiKey;
        private readonly RouteHttpClient client;
    }
}
