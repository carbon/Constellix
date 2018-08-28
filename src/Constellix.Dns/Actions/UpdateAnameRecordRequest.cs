using System.Runtime.Serialization;

namespace Constellix.Dns
{
    public sealed class UpdateAnameRecordRequest : UpdateRecordRequest
    {
        public UpdateAnameRecordRequest(long domainId, long recordId, string name, params ANameRecordValue[] value)
           : base(domainId, recordId, name)
        {
            RoundRobin = value;
        }

        [IgnoreDataMember]
        public override RecordType Type => RecordType.ANAME;

        [DataMember(Name = "roundRobin")]
        public ANameRecordValue[] RoundRobin { get; }
    }
}