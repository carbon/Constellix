#nullable disable

using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Constellix.Dns
{
    public class Record
    {
        public long Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public RecordType Type { get; set; }

        public string RecordType { get; set; }

        public string Name { get; set; }

        public string RecordOption { get; set; }

        public bool? NoAnswer { get; set; }

        public int Ttl { get; set; }
        
        // TODO: Geolocation

        public string Note { get; set; }

        public int GtdRegion { get; set; }

        public long ParentId { get; set; }

        // e.g. domain
        public string Parent { get; set; }

        // e.g. Domain
        public string Source { get; set; }

        // milliseconds since 1970
        public long ModifiedTs { get; set; }

        // A : [ ip, .. ]
        // CNAME: 
        // [DataMember(Name = "value")]
        // public JsonNode Value { get; set; }

        public JsonElement RoundRobin { get; set; }

        // ???
        [DataMember(Name = "hardlinkFlag", EmitDefaultValue = false)]
        public bool HardlinkFlag { get; set; }

        #region Redirect Records

        public string Url { get; set; }

        public int? RedirectTypeId { get; set; }

        #endregion

        #region CNAME Records

        public string Host { get; set; }

        #endregion
    }
}