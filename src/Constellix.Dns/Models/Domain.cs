#nullable disable

using System;
using System.Text.Json.Serialization;

namespace Constellix.Dns
{
    public sealed class Domain
    {
        [JsonPropertyName("id")]
        public long Id { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("typeId")]
        public int TypeId { get; init; }

        [JsonPropertyName("hasGtdRegions")]
        public bool HasGtdRegions { get; init; }

        [JsonPropertyName("hasGeoIP")]
        public bool HasGeoIP { get; init; }

        [JsonPropertyName("nameserverGroup")]
        public int? NameserverGroup { get; init; }

        [JsonPropertyName("nameservers")]
        public string[] Nameservers { get; init; }

#nullable enable

        [JsonPropertyName("soa")]
        public Soa? Soa { get; set; }
        
        public DateTimeOffset CreatedTs { get; init; }

        public DateTimeOffset ModifiedTs { get; init; }

        public string[]? DomainTags { get; init; }

        [JsonPropertyName("folder")]
        public string? Folder { get; init; }

        [JsonPropertyName("note")]
        public string? Note { get; init; }

        public int Version { get; set; }

        public string Status { get; init; }

        [JsonPropertyName("tags")]
        public string[]? Tags { get; init; }

        [JsonPropertyName("vanityNameServerDetails")]
        public VanityNameServerDetails? VanityNameServerDetails { get; init; }
    }

}
 