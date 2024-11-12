using Newtonsoft.Json;
using System.Reflection;
using System.Text.Json.Serialization;
using JsonConverter = Newtonsoft.Json.JsonConverter;

namespace RouteFinder.API.Utils.Serialization
{
    public class GoogleApiJsonPropertyNamesConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
            => !objectType.IsEquivalentTo(typeof(string));

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
            => serializer.Deserialize(reader, objectType);

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            var objectType = value.GetType();
            var properties = objectType.GetProperties();

            writer.WriteStartObject();
            foreach (var property in properties)
            {
                var jsonPropertyNameAttr = property.GetCustomAttribute<JsonPropertyNameAttribute>();
                string jsonPropertyName = jsonPropertyNameAttr?.Name ?? property.Name;
                string jsonPropertyNameCamelcase = ToCamelCase(jsonPropertyName);
                var propertyValue = property.GetValue(value);

                writer.WritePropertyName(jsonPropertyNameCamelcase);
                serializer.Serialize(writer, propertyValue);
            }
            writer.WriteEndObject();
        }

        private static string ToCamelCase(string? value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            var firstCharLowerCase = value.ToLower()[0];
            var camelCaseString = $"{firstCharLowerCase}{value[1..]}";

            return camelCaseString;
            
        }
    }
}
