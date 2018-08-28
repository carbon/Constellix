using System;
using System.Runtime.Serialization;

namespace Constellix.Dns
{
    public sealed class CreateMXRecordRequest : CreateRecordRequest
    {
        public CreateMXRecordRequest(long domainId, string name, int ttl = 3600, params MXRecordValue[] values)
           : base(domainId, name, ttl)
        {
            RoundRobin = values ?? throw new ArgumentNullException(nameof(values));
        }

        [IgnoreDataMember]
        public override RecordType Type => RecordType.MX;

        [DataMember(Name = "roundRobin")]
        public MXRecordValue[] RoundRobin { get; }
    }

    // https://api-dns-docs.constellix.com/
}
