using System.Runtime.Serialization;

namespace Constellix.Dns
{

    public class CreateANameRecordRequest : CreateRecordRequest
    {
        public CreateANameRecordRequest(long domainId, string name, int ttl = 3600, params ANameRecordValue[] values)
            : base(domainId, name, ttl)
        {
            RoundRobin = values;
        }

        [IgnoreDataMember]
        public override RecordType Type => RecordType.ANAME;

        [DataMember(Name = "roundRobin")]
        public ANameRecordValue[] RoundRobin { get; }

    }
}
