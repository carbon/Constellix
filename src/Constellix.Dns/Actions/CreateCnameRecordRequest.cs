using System.Text.Json.Serialization;

namespace Constellix.Dns
{
    public sealed class CreateCnameRecordRequest : CreateRecordRequest
    {
        public CreateCnameRecordRequest(long domainId, string name, string host, int ttl = 3600)
           : base(domainId, name, ttl)
        {
            Host = host;
        }

        [JsonIgnore]
        public override RecordType Type => RecordType.CNAME;

        public string Host { get; init; }
    }
}