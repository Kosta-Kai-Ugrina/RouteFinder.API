namespace RouteFinder.API.Utils.Serialization;

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
}
