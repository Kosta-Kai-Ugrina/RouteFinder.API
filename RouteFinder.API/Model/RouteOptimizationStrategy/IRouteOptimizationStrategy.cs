namespace RouteFinder.API.Model.RouteOptimizationStrategy;

public interface IRouteOptimizationStrategy
{
    public RouteRequest OptimizeRoute(RouteRequest routeRequest);
}
