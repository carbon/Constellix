#nullable disable

using System.Text.Json.Serialization;

namespace Constellix.Dns
{
    public sealed class CaaRecordValue
    {
        [JsonPropertyName("flag")]
        public int Flag { get; set; }

        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        [JsonPropertyName("data")]
        public string Data { get; set; }

        [JsonPropertyName("caaProviderId")]
        public int CaaProviderId { get; set; }

        [JsonPropertyName("disableFlag")]
        public bool? DisableFlag { get; set; }
    }
}