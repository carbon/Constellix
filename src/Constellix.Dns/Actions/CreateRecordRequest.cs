using System;
using System.Runtime.Serialization;

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

        [IgnoreDataMember]
        public long DomainId { get; }

        [DataMember(Name = "name")]
        public string Name { get; }

        [DataMember(Name = "ttl", EmitDefaultValue = false)]
        public int Ttl { get; }

        [IgnoreDataMember]
        public abstract RecordType Type { get; }
    }
}