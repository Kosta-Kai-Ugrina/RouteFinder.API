using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Routes.Common;
using GoogleApi.Entities.Maps.Routes.Directions.Request;

namespace RouteFinder.API.Utils
{
    public class RouteExamples
    {
        public static RoutesDirectionsRequest Example01()
        {
            var routeRequest = RouteHttpClient.RequestTemplate;
            routeRequest.Origin = new RouteWayPoint
            {
                Location = new RouteLocation
                {
                    LatLng = new LatLng
                    {
                        Latitude = 55.66221993583325,
                        Longitude = 12.577998762094255,
                    }
                }
            };
            routeRequest.Destination = new RouteWayPoint
            {
                Location = new RouteLocation
                {
                    LatLng = new LatLng
                    {
                        Latitude = 55.66020591154689,
                        Longitude = 12.572785483070883,
                    }
                }
            };
            return routeRequest;
        }
    }
}
