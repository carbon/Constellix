using System.Text.Json.Serialization;

namespace Constellix.Dns
{
    public sealed class UpdateAnameRecordRequest : UpdateRecordRequest
    {
        public UpdateAnameRecordRequest(long domainId, long recordId, string name, params ANameRecordValue[] value)
           : base(domainId, recordId, name)
        {
            RoundRobin = value;
        }

        [JsonIgnore]
        public override RecordType Type => RecordType.ANAME;

        public ANameRecordValue[] RoundRobin { get; }
    }
}