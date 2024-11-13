using RouteFinder.API.Model.RequestData;

namespace RouteFinder.API.Model.RouteOptimization
{
    public interface IRouteOptimizationStrategy
    {
        public RouteRequest OptimizeRoute(RouteRequest routeRequest);
    }
}
