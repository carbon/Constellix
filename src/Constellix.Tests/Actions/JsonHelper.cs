using System.Text.Json;

namespace Constellix.Dns.Tests
{
    public static class JsonHelper
    {
        public static readonly JsonSerializerOptions Options = new JsonSerializerOptions {
            IgnoreNullValues = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }
}