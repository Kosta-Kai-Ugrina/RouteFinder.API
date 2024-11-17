namespace RouteFinder.API.Service;

public class RouteOptimizationService
{
    public RouteOptimizationService()
    {
        this.strategy = new NearestNeighborStrategy();
    }

    public RouteOptimizationService(IRouteOptimizationStrategy strategy)
    {
        this.strategy = strategy;
    }

    public RouteRequest OptimizeRoute(RouteRequest routeRequest)
        => this.strategy.OptimizeRoute(routeRequest);

    private IRouteOptimizationStrategy strategy;
}
