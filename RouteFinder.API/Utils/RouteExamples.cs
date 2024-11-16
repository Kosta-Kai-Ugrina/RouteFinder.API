using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Routes.Common;
using GoogleApi.Entities.Maps.Routes.Directions.Request;
using RouteFinder.API.Model;

namespace RouteFinder.API.Utils
{
    public static class RouteExamples
    {
        public static RoutesDirectionsRequest ExampleSimple()
        {
            var routeRequest = RouteHttpClient.RequestTemplate;

            routeRequest.Origin = moverSystems;
            routeRequest.Destination = nettoOnArtillerivej;

            return routeRequest;
        }

        public static RoutesDirectionsRequest ExampleWrongOrder1()
        {
            var routeRequest = RouteHttpClient.RequestTemplate;
            
            routeRequest.Origin = moverSystems;
            routeRequest.Intermediates = [cafeNoah];
            routeRequest.Destination = nettoOnArtillerivej;

            return routeRequest;
        }

        public static RoutesDirectionsRequest ExampleWrongOrder2()
        {
            var routeRequest = RouteHttpClient.RequestTemplate;

            routeRequest.Origin = moverSystems;
            routeRequest.Intermediates = [reffen, nettoOnArtillerivej, aliceIceCreamAndCoffee];
            routeRequest.Destination = cafeNoah;

            return routeRequest;
        }

        private static readonly RouteWayPoint moverSystems = new RouteWayPoint
        {
            Address = "Mover Systems",
            Location = new RouteLocation
            {
                LatLng = new LatLng
                {
                    Latitude = 55.66221993583325,
                    Longitude = 12.577998762094255,
                }
            }
        };
        private static readonly RouteWayPoint nettoOnArtillerivej = new RouteWayPoint
        {
            Address = "Netto on Artillerivej",
            Location = new RouteLocation
            {
                LatLng = new LatLng
                {
                    Latitude = 55.66020591154689,
                    Longitude = 12.572785483070883,
                }
            }
        };
        private static readonly RouteWayPoint cafeNoah = new RouteWayPoint
        {
            Address = "Cafe Noah",
            Location = new RouteLocation
            {
                LatLng = new LatLng
                {
                    Latitude = 55.65510688427592,
                    Longitude = 12.5652663425789,
                }
            }
        };
        private static readonly RouteWayPoint reffen = new RouteWayPoint
        {
            Address = "Reffen",
            Location = new RouteLocation
            {
                LatLng = new LatLng
                {
                    Latitude = 55.69376270561271,
                    Longitude = 12.607666137085154,
                }
            }
        };
        private static readonly RouteWayPoint aliceIceCreamAndCoffee = new RouteWayPoint
        {
            Address = "Alice Ice Cream and Coffee",
            Location = new RouteLocation
            {
                LatLng = new LatLng
                {
                    Latitude = 55.66845638233031,
                    Longitude = 12.597300106161562,
                }
            }
        };
    }
}
