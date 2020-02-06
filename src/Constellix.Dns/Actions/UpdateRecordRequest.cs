using System;
using System.Text.Json.Serialization;

namespace Constellix.Dns
{
    public abstract class UpdateRecordRequest
    {
        public UpdateRecordRequest(long domainId, long recordId, string name)
        {
            if (domainId <= 0)
            {
                throw new ArgumentException("Must be > 0", nameof(domainId));
            }

            if (recordId <= 0)
            {
                throw new ArgumentException("Must be > 0", nameof(recordId));
            }

            DomainId = domainId;
            RecordId = recordId;
            Name = name;
        }

        [JsonIgnore]
        public long DomainId { get; }
        
        public string Name { get; }

        public int? Ttl { get; set; }

        [JsonIgnore]
        public long RecordId { get; }

        [JsonIgnore]
        public abstract RecordType Type { get; }
    }
}
