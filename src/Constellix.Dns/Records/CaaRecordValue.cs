#nullable disable

using System.Runtime.Serialization;

namespace Constellix.Dns
{
    public sealed class CaaRecordValue
    {
        [DataMember(Name = "flag")]
        public int Flag { get; set; }

        [DataMember(Name = "tag")]
        public string Tag { get; set; }

        [DataMember(Name = "data")]
        public string Data { get; set; }

        [DataMember(Name = "caaProviderId")]
        public int CaaProviderId { get; set; }

        [DataMember(Name = "disableFlag", EmitDefaultValue = false)]
        public bool DisableFlag { get; set; }
    }
}