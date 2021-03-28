#nullable disable

using System.Text.Json.Serialization;

namespace Constellix.Dns
{
    public class Template
    {
        [JsonPropertyName("id")]
        public long Id { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("domain")]
        public long Domain { get; init; }

        [JsonPropertyName("hasGtdRegions")]
        public bool HasGtdRegions { get; init; }

        [JsonPropertyName("hasGeoIP")]
        public bool HasGeoIP { get; init; }

        [JsonPropertyName("version")]
        public int Version { get; init; }
    }
}