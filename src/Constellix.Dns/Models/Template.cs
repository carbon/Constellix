#nullable disable

using System.Text.Json.Serialization;

namespace Constellix.Dns
{
    public class Template
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("domain")]
        public long Domain { get; set; }

        [JsonPropertyName("hasGtdRegions")]
        public bool HasGtdRegions { get; set; }

        [JsonPropertyName("hasGeoIP")]
        public bool HasGeoIP { get; set; }

        [JsonPropertyName("version")]
        public int Version { get; set; }
    }
}