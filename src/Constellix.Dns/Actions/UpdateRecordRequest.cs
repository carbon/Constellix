using System;
using System.Runtime.Serialization;

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

        [IgnoreDataMember]
        public long DomainId { get; }
        
        [DataMember(Name = "name")]
        public string Name { get; }

        [DataMember(Name = "ttl", EmitDefaultValue = false)]
        public int Ttl { get; set; }

        [IgnoreDataMember]
        public long RecordId { get; }
        
        [IgnoreDataMember]
        public abstract RecordType Type { get; }
    }
}
