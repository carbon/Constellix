#nullable disable

using System.Runtime.Serialization;

namespace Constellix.Dns
{
    public class Template
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "domain")]
        public long Domain { get; set; }

        [DataMember(Name = "hasGtdRegions")]
        public bool HasGtdRegions { get; set; }

        [DataMember(Name = "hasGeoIP")]
        public bool HasGeoIP { get; set; }

        [DataMember(Name = "version")]
        public int Version { get; set; }
    }
}