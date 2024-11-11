using RouteFinder.API.Model;

namespace RouteFinder.API.Service
{
    public class RoutesService
    {
        public RoutesService(WebApplicationBuilder builder)
        {
            this.googleApiKey = builder.Configuration["GoogleApiKey"];
        }

        public string? GetGoogleApiKey(string password)
        {
            if (password != "PrettyPlease") return null;
            return googleApiKey;
        }

        public async Task<List<Address>> FindFastestRoute(
            RouteRequest routeRequest)
        {
            var addressStart = routeRequest.AddressStart;
            var addressDestinationList = routeRequest.AddressDestinationList;

            return [addressStart, .. addressDestinationList];
        }

        private readonly string googleApiKey;
    }
}
