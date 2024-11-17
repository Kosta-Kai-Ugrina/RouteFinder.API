using GoogleApi.Entities.Maps.Routes.Directions.Request;
using RouteFinder.API.Model.RequestData;

namespace RouteFinder.API.Extensions
{
    public static partial class Extensions
    {
        public static RouteRequest ToRouteRequest(this RoutesDirectionsRequest routeData)
            => new()
            {
                AddressStart = routeData.Origin.ToAddressRequest(),
                AddressDestinationList = routeData
                    .Intermediates
                    .Select(waypoint => waypoint.ToAddressRequest())
                    .Append(routeData.Destination.ToAddressRequest())
                    .ToList(),
            };
    }
}
