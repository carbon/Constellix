using System.Text.Json;
using System.Text.Json.Serialization;

namespace Constellix.Dns.Tests
{
    public static class JsonHelper
    {
        public static readonly JsonSerializerOptions Options = new () {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }
}