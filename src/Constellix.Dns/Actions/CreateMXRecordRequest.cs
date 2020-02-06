using System;
using System.Text.Json.Serialization;

namespace Constellix.Dns
{
    public sealed class CreateMXRecordRequest : CreateRecordRequest
    {
        public CreateMXRecordRequest(long domainId, string name, int ttl = 3600, params MXRecordValue[] values)
           : base(domainId, name, ttl)
        {
            RoundRobin = values ?? throw new ArgumentNullException(nameof(values));
        }

        [JsonIgnore]
        public override RecordType Type => RecordType.MX;

        public MXRecordValue[] RoundRobin { get; }
    }

    // https://api-dns-docs.constellix.com/
}
