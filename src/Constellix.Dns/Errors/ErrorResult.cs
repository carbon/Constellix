#nullable disable

using System.Text.Json.Serialization;

namespace Constellix.Dns
{
    public class ErrorResult
    {
        [JsonPropertyName("errors")]
        public string[] Errors { get; set; }
    }
}

// {"errors":["Record not found"]}