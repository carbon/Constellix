#nullable disable

using System.Text.Json.Serialization;

namespace Constellix.Dns
{
    public class Soa
    {        
        [JsonPropertyName("primaryNameserver")]
        public string PrimaryNameserver { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
        
        [JsonPropertyName("ttl")]
        public int Ttl { get; set; }

        [JsonPropertyName("serial")]
        public int Serial { get; set; }

        [JsonPropertyName("refresh")]
        public int Refresh { get; set; }

        [JsonPropertyName("retry")]
        public int Retry { get; set; }

        [JsonPropertyName("expire")]
        public int Expire { get; set; }

        [JsonPropertyName("negCache")]
        public int NegCache { get; set; }
    }

}