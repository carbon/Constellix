using System;
using System.Text.Json.Serialization;

namespace Constellix.Dns
{
    public abstract class CreateRecordRequest
    {
        public CreateRecordRequest(long domainId, string name, int ttl)
        {
            if (domainId <= 0)
            {
                throw new ArgumentException("Must be > 0", nameof(domainId));
            }

            DomainId = domainId;
            Name = name;
            Ttl = ttl;
        }

        [JsonIgnore]
        public long DomainId { get; }

        public string Name { get; }

        public int? Ttl { get; }

        [JsonIgnore]
        public abstract RecordType Type { get; }
    }
}