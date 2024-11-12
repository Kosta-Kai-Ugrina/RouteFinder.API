
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RouteFinder.API.Utils.Serialization
{
    public class GoogleApiEnumMemberAttributeStringConverter : JsonConverter<object?>
    {


        //public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        //{
        //    if (value == null)
        //    {
        //        writer.WriteNull();
        //        return;
        //    }

        //    string? enumStringValue = ExtractEnumMemberAttributeValue(value as Enum);
        //    writer.WriteValue(enumStringValue);
        //}

        private static string ExtractEnumMemberAttributeValue(Enum e)
        {
            var enumType = e.GetType();
            var memberInfos = enumType.GetMember(e.ToString());
            var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
            var enumMember = enumValueMemberInfo
                .GetCustomAttributes(typeof(EnumMemberAttribute), false)[0] as EnumMemberAttribute;
            var enumMemberValue = enumMember.Value;

            return enumMemberValue;
        }

        public override bool CanConvert(Type typeToConvert)
            => (Nullable.GetUnderlyingType(typeToConvert) ?? typeToConvert).IsEnum;

        public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, object? value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }
            string? enumStringValue = ExtractEnumMemberAttributeValue(value as Enum);
            writer.WriteStringValue(enumStringValue);
        }
    }
}
