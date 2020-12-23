using System;
using System.Text.Json.Serialization;

namespace Constellix.Dns
{
    public sealed class CreateDomainRequest
    {
        public CreateDomainRequest(params string[] names)
        {
            Names = names ?? throw new ArgumentNullException(nameof(names));
        }

        [JsonPropertyName("names")]
        public string[] Names { get;  }
    }
}