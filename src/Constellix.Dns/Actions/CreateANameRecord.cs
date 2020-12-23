using System.Text.Json.Serialization;

namespace Constellix.Dns
{
    public sealed class CreateANameRecordRequest : CreateRecordRequest
    {
        public CreateANameRecordRequest(long domainId, string name, int ttl = 3600, params ANameRecordValue[] values)
            : base(domainId, name, ttl)
        {
            RoundRobin = values;
        }

        [JsonIgnore]
        public override RecordType Type => RecordType.ANAME;

        public ANameRecordValue[] RoundRobin { get; }
    }
}