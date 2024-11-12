//using Newtonsoft.Json;
//using Newtonsoft.Json.Serialization;

using System.Text.Json;

namespace RouteFinder.API.Utils.Serialization
{
    public static class GoogleApiJsonConverter
    {

        public static string Serialize(object obj)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            options.Converters.Add(new GoogleApiEnumMemberAttributeStringConverter());
            var jsonObj = JsonSerializer.Serialize(obj, options);
            return jsonObj;
        }

        //public static string Serialize(object obj)
        //    => JsonConvert.SerializeObject(
        //        value: obj,
        //        settings: new JsonSerializerSettings
        //        {
        //            Converters = [
        //                new GoogleApiEnumUppercaseStringConverter(),
        //                new GoogleApiJsonPropertyNamesConverter()],
        //            ContractResolver = new CamelCasePropertyNamesContractResolver(),
        //        });
    }
}
