using GoogleApi.Entities.Maps.Routes.Common.Enums;
using GoogleApi.Entities.Maps.Routes.Common;
using GoogleApi.Entities.Maps.Routes.Directions.Request;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Common.Enums;
using RouteFinder.API.Utils.Serialization;
using System.Runtime.CompilerServices;
using System.Reflection.Metadata;
using System.Text;
using GoogleApi.Entities.Maps.Routes.Directions.Response;
using RouteFinder.API.Model.RequestData;

namespace RouteFinder.API.Model
{
    public class RouteHttpClient
    {
        public static RouteHttpClient Create(string googleApiKey)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-Goog-Api-Key", googleApiKey);
            client.DefaultRequestHeaders.Add("X-Goog-FieldMask", "routes.duration,routes.distanceMeters,routes.polyline.encodedPolyline");
            var routeClient = new RouteHttpClient(client);
            return routeClient;
        }

        private RouteHttpClient(HttpClient client)
        {
            this.client = client;
        }

        public async Task<RouteResponse?> RequestRouteDirections(RoutesDirectionsRequest data)
        {
            var dataJson = GoogleApiJsonConverter.Serialize(data);
            var content = new StringContent(
                content: dataJson,
                encoding: Encoding.UTF8,
                mediaType: "application/json");

            var response = await client.PostAsync(uri, content);
            var responseContentBla = await response.Content.ReadAsStringAsync();
            var responseContent = await response.Content.ReadFromJsonAsync(typeof(RouteResponse));

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return responseContent as RouteResponse;
        }


        public static RoutesDirectionsRequest RequestTemplate
            => new RoutesDirectionsRequest
            {
                TravelMode = RouteTravelMode.Drive,
                RoutingPreference = RoutingPreference.TrafficAware,
                ComputeAlternativeRoutes = false,
                RouteModifiers = new RouteModifiers
                {
                    AvoidTolls = false,
                    AvoidFerries = false,
                    AvoidHighways = false,
                },
                Units = Units.Metric,
                Language = Language.English,
            };

        private readonly HttpClient client;
        private readonly Uri uri = new Uri("https://routes.googleapis.com/directions/v2:computeRoutes");
    }
}
