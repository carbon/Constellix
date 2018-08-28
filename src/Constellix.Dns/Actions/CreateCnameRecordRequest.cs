using System.Runtime.Serialization;

namespace Constellix.Dns
{
    public sealed class CreateCnameRecordRequest : CreateRecordRequest
    {
        public CreateCnameRecordRequest(long domainId, string name, string host, int ttl = 3600)
           : base(domainId, name, ttl)
        {
            Host = host;
        }

        [IgnoreDataMember]
        public override RecordType Type => RecordType.CNAME;

        [DataMember(Name = "host")]
        public string Host { get; set; }
    }
}