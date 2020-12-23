#nullable disable

using System;
using System.Text.Json.Serialization;

namespace Constellix.Dns
{
    public class Domain
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("typeId")]
        public int TypeId { get; set; }

        [JsonPropertyName("hasGtdRegions")]
        public bool HasGtdRegions { get; set; }

        [JsonPropertyName("hasGeoIP")]
        public bool HasGeoIP { get; set; }

        [JsonPropertyName("nameserverGroup")]
        public int? NameserverGroup { get; set; }

        [JsonPropertyName("nameservers")]
        public string[] Nameservers { get; set; }

#nullable enable

        [JsonPropertyName("soa")]
        public Soa? Soa { get; set; }
        
        public DateTimeOffset CreatedTs { get; set; }

        public DateTimeOffset ModifiedTs { get; set; }

        public string[]? DomainTags { get; set; }

        [JsonPropertyName("folder")]
        public string? Folder { get; set; }

        [JsonPropertyName("note")]
        public string? Note { get; set; }

        public int Version { get; set; }

        public string Status { get; set; }

        [JsonPropertyName("tags")]
        public string[]? Tags { get; set; }

        [JsonPropertyName("vanityNameServerDetails")]
        public VanityNameServerDetails? VanityNameServerDetails { get; set; }
    }

}
 