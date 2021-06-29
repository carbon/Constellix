#nullable disable

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Constellix.Dns
{
    public sealed class Record
    {
        public long Id { get; init; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public RecordType Type { get; init; }

        public string RecordType { get; init; }

        public string Name { get; init; }

        public string RecordOption { get; init; }

        public bool? NoAnswer { get; init; }

        public int Ttl { get; init; }
        
        // TODO: Geolocation

        public string Note { get; init; }

        public int GtdRegion { get; init; }

        public long ParentId { get; init; }

        // e.g. domain
        public string Parent { get; init; }

        // e.g. Domain
        public string Source { get; init; }

        // milliseconds since 1970
        public long ModifiedTs { get; init; }

        // A : [ ip, .. ]
        // CNAME: 
        // [JsonPropertyName("value")]
        // public JsonNode Value { get; set; }

        public JsonElement RoundRobin { get; init; }

        // ???
        [JsonPropertyName("hardlinkFlag")]
        public bool? HardlinkFlag { get; init; }

        #region Redirect Records

        public string Url { get; init; }

        public int? RedirectTypeId { get; init; }

        #endregion

        #region CNAME Records

        public string Host { get; init; }

        #endregion
    }
}