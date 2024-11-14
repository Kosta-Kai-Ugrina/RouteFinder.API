using RouteFinder.API.Model.Extensions;
using RouteFinder.API.Model.RequestData;
using RouteFinder.API.Model.RouteOptimization;
using RouteFinder.API.Utils;

namespace RouteFinder.API.Service
{
    public class RoutesService
    {
        public RoutesService(WebApplicationBuilder builder)
        {
            this.googleApiKey = builder.Configuration["GoogleApiKey"];
            this.client = new RouteHttpClient(RouteHttpClient.CreateHttpClientTemplate(this.googleApiKey));
            this.optimizer = new RouteOptimizer();
        }

        public async Task<List<AddressRequest>> FindFastestRoute(
            RouteRequest routeRequest)
        {
            var addressStart = routeRequest.AddressStart;
            var addressDestinationList = routeRequest.AddressDestinationList;

            return [addressStart, .. addressDestinationList];
        }

        public async Task<string> TryRoute()
        {
            var routeData = RouteExamples.ExampleSimple();
            var responseContent = await client.RequestRouteDirections(routeData);

            return responseContent;
        }

        public string TestNearestNeighborOptimizationAlgorithm1()
        {
            var routeData = RouteExamples.ExampleWrongOrder1();
            var optimizer = new RouteOptimizer(new NearestNeighborStrategy());
            var optimizedRouteData = optimizer.OptimizeRoute(routeData.ToRouteRequest());

            return optimizedRouteData.ToString();
        }

        public string TestNearestNeighborOptimizationAlgorithm2()
        {
            var routeData = RouteExamples.ExampleWrongOrder2();
            var optimizer = new RouteOptimizer(new NearestNeighborStrategy());
            var optimizedRouteData = optimizer.OptimizeRoute(routeData.ToRouteRequest());

            return optimizedRouteData.ToString();
        }

        public RouteRequest FindOptimalAddressOrder(RouteRequest routeRequest)
        {
            var optimizedRouteData = this.optimizer.OptimizeRoute(routeRequest);

            return optimizedRouteData;
        }

        private readonly RouteOptimizer optimizer;
        private readonly string googleApiKey;
        private readonly RouteHttpClient client;
    }
}
