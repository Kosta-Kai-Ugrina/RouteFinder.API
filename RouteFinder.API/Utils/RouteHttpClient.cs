using GoogleApi.Entities.Maps.Routes.Common.Enums;
using GoogleApi.Entities.Maps.Routes.Common;
using GoogleApi.Entities.Maps.Routes.Directions.Request;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Common.Enums;
using RouteFinder.API.Utils.Serialization;
using System.Runtime.CompilerServices;
using System.Reflection.Metadata;
using System.Text;

namespace RouteFinder.API.Utils
{
    public class RouteHttpClient
    {
        public RouteHttpClient(HttpClient client)
        {
            this.client = client;
        }

        public async Task<string> RequestRouteDirections(RoutesDirectionsRequest data)
        {
            var dataJson = GoogleApiJsonConverter.Serialize(data);
            var content = new StringContent(
                content: dataJson,
                encoding: Encoding.UTF8,
                mediaType: "application/json");

            var response = await this.client.PostAsync(this.uri, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return $"FAILED\n\n\nREQUEST BODY:\n{dataJson}\n\nRESPONSE:\n{responseContent}";
            }
            
            return $"SUCCESS\n\n\nREQUEST BODY:\n{dataJson}\n\nRESPONSE:\n{responseContent}";
        }

        public static HttpClient CreateHttpClientTemplate(string googleApiKey)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-Goog-Api-Key", googleApiKey);
            client.DefaultRequestHeaders.Add("X-Goog-FieldMask", "routes.duration,routes.distanceMeters,routes.polyline.encodedPolyline");
            return client;
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
