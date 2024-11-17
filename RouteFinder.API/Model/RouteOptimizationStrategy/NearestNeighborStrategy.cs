using static RouteFinder.API.Utils.DistanceCalculator;

namespace RouteFinder.API.Model.RouteOptimizationStrategy
{
    public class NearestNeighborStrategy : IRouteOptimizationStrategy
    {
        public RouteRequest OptimizeRoute(RouteRequest routeRequest)
        {
            var addressStart = routeRequest.AddressStart;
            var destinationList = routeRequest.AddressDestinationList.ToList();
            var optimizedRoute = new List<AddressRequest>();

            while (destinationList.Any())
            {
                var target = optimizedRoute.LastOrDefault() ?? addressStart;
                var (nearestAddress, remainingDestinations) =
                    FindNearestAddress(target, destinationList);
                optimizedRoute.Add(nearestAddress);
                destinationList = remainingDestinations;
            }

            return new RouteRequest
            {
                AddressStart = addressStart,
                AddressDestinationList = optimizedRoute
            };
        }

        private (AddressRequest, List<AddressRequest>) FindNearestAddress(
            AddressRequest target,
            List<AddressRequest> destinationList)
        {
            var destinationListSorted = destinationList
                .Select(addr => ToDistanceAddressPair(target, addr))
                .OrderBy(x => x.distanceFromTarget)
                .Select(x => x.address);

            return (
                destinationListSorted.First(),
                destinationListSorted.Skip(1).ToList());
        }

        private (double distanceFromTarget, AddressRequest address) ToDistanceAddressPair(
            AddressRequest target,
            AddressRequest current)
        {
            var distance = CalculateManhattanDistance(target, current);
            return (distance, current);
        }
    }
}
