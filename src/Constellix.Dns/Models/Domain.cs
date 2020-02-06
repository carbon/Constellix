#nullable disable

using System;
using System.Runtime.Serialization;

namespace Constellix.Dns
{
    public class Domain
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "typeId")]
        public int TypeId { get; set; }

        [DataMember(Name = "hasGtdRegions")]
        public bool HasGtdRegions { get; set; }

        [DataMember(Name = "hasGeoIP")]
        public bool HasGeoIP { get; set; }

        [DataMember(Name = "nameserverGroup", EmitDefaultValue = false)]
        public int NameserverGroup { get; set; }

        [DataMember(Name = "nameservers", EmitDefaultValue = false)]
        public string[] Nameservers { get; set; }

        [DataMember(Name = "soa", EmitDefaultValue = false)]
        public Soa Soa { get; set; }
        
        public DateTimeOffset CreatedTs { get; set; }

        public DateTimeOffset ModifiedTs { get; set; }

        public string[] DomainTags { get; set; }

        [DataMember(Name = "folder")]
        public string Folder { get; set; }

        [DataMember(Name = "note", EmitDefaultValue = false)]
        public string Note { get; set; }

        public int Version { get; set; }

        public string Status { get; set; }

        [DataMember(Name = "tags", EmitDefaultValue = false)]
        public string[] Tags { get; set; }


        [DataMember(Name = "vanityNameServerDetails", EmitDefaultValue = false)]
        public VanityNameServerDetails VanityNameServerDetails { get; set; }
    }

    /*
   
      "vanityNameServer": 399,
      "vanityNameServerName": "dn3.net",
      */

    public class VanityNameServerDetails
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public bool IsDefault { get; set; }

        public bool IsPublic { get; set; }

        public string[] NameServers { get; set; }

        public long NameserverGroup { get; set; }

        public string NameserverGroupName { get; set; }

        public string NameserversListString { get; set; }
    }

}
 