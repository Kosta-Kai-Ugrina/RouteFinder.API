using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace RouteFinder.API.Utils.Serialization
{
    public static class GoogleApiJsonConverter
    {
        public static string Serialize(object obj)
            => JsonConvert.SerializeObject(
                value: obj,
                settings: new JsonSerializerSettings
                {
                    Converters = [
                        new GoogleApiEnumUppercaseStringConverter(),
                        new GoogleApiJsonPropertyNamesConverter()],
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                });
    }
}
