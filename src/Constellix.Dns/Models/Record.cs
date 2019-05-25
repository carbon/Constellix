#nullable disable

using System.Runtime.Serialization;

using Carbon.Json;

namespace Constellix.Dns
{
    public class Record
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "type")]
        public RecordType Type { get; set; }

        [DataMember(Name = "recordType")]
        public string RecordType { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "recordOption")]
        public string RecordOption { get; set; }

        [DataMember(Name = "noAnswer", EmitDefaultValue = false)]
        public bool NoAnswer { get; set; }

        [DataMember(Name = "ttl")]
        public int Ttl { get; set; }
        
        // TODO: Geolocation

        [DataMember(Name = "note", EmitDefaultValue = false)]
        public string Note { get; set; }

        [DataMember(Name = "gtdRegion")]
        public int GtdRegion { get; set; }

        [DataMember(Name = "parentId")]
        public long ParentId { get; set; }

        // e.g. domain
        [DataMember(Name = "parent")]
        public string Parent { get; set; }

        // e.g. Domain
        [DataMember(Name = "source")]
        public string Source { get; set; }

        // milliseconds since 1970
        [DataMember(Name = "modifiedTs")]
        public long ModifiedTs { get; set; }

        // A : [ ip, .. ]
        // CNAME: 
        // [DataMember(Name = "value")]
        // public JsonNode Value { get; set; }

        [DataMember(Name = "roundRobin")]
        public JsonArray RoundRobin { get; set; }

        // ???
        [DataMember(Name = "hardlinkFlag", EmitDefaultValue = false)]
        public bool HardlinkFlag { get; set; }

        #region Redirect Records

        [DataMember(Name = "url", EmitDefaultValue = false)]
        public string Url { get; set; }

        [DataMember(Name = "redirectTypeId", EmitDefaultValue = false)]
        public int? RedirectTypeId { get; set; }

        #endregion

        #region CNAME Records

        [DataMember(Name = "host", EmitDefaultValue = false)]
        public string Host { get; set; }

        #endregion
    }



    

}