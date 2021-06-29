#nullable disable

using System.Text.Json.Serialization;

namespace Constellix.Dns
{
    public sealed class CaaRecordValue
    {
        [JsonPropertyName("flag")]
        public int Flag { get; init; }

        [JsonPropertyName("tag")]
        public string Tag { get; init; }

        [JsonPropertyName("data")]
        public string Data { get; init; }

        [JsonPropertyName("caaProviderId")]
        public int CaaProviderId { get; init; }

        [JsonPropertyName("disableFlag")]
        public bool? DisableFlag { get; init; }
    }
}