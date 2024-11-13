using RouteFinder.API.Model.RequestData;

namespace RouteFinder.API.Model.RouteOptimization
{
    public class RouteOptimizer
    {
        public RouteOptimizer() 
        { 
            this.strategy = new NearestNeighborStrategy();
        }

        public RouteOptimizer(IRouteOptimizationStrategy strategy)
        {
            this.strategy = strategy;
        }

        public RouteRequest OptimizeRoute(RouteRequest routeRequest)
            => this.strategy.OptimizeRoute(routeRequest);

        private IRouteOptimizationStrategy strategy;
    }
}
