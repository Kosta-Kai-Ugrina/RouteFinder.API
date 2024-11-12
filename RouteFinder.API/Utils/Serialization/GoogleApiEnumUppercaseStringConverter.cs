using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

namespace RouteFinder.API.Utils.Serialization
{
    public class GoogleApiEnumUppercaseStringConverter : StringEnumConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            string? enumStringValue = ExtractEnumMemberAttributeValue(value as Enum);
            writer.WriteValue(enumStringValue);
        }

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
    }
}
