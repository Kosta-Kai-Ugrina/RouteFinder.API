using RouteFinder.API.Model.RequestData;

namespace RouteFinder.API.Model.RouteOptimizationStrategy
{
    public class BogoStrategy : IRouteOptimizationStrategy
    {
        public RouteRequest OptimizeRoute(RouteRequest routeRequest)
        {
            var destinations = routeRequest.AddressDestinationList;
            List<AddressRequest> list = DoNothing(destinations);
            routeRequest.AddressDestinationList = list;
            
            return routeRequest;
        }

        private List<AddressRequest> DoNothing(List<AddressRequest> destinations)
        {
            return destinations;
        }
    }
}
