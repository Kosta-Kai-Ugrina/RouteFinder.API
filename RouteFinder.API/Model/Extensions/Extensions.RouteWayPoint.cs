using GoogleApi.Entities.Maps.Routes.Common;
using RouteFinder.API.Model.RequestData;

namespace RouteFinder.API.Model.Extensions
{
    public static partial class Extensions
    {
        public static AddressRequest ToAddressRequest(this RouteWayPoint wayPoint)
            => new()
            {
                Name = wayPoint.Address,
                Latitude = wayPoint.Location.LatLng.Latitude,
                Longitude = wayPoint.Location.LatLng.Longitude,
            };
    }
}
