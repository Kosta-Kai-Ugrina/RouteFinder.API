
namespace RouteFinder.API.Extensions
{
    public static partial class Extensions
    {
        public static AddressRequest ToAddressRequest(this RouteWayPoint wayPoint)
            => new()
            {
                Name = wayPoint.Address ?? string.Empty,
                Latitude = wayPoint.Location.LatLng.Latitude,
                Longitude = wayPoint.Location.LatLng.Longitude,
            };
    }
}
