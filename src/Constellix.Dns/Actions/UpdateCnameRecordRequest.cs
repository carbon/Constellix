using System;
using System.Text.Json.Serialization;

namespace Constellix.Dns
{
    public sealed class UpdateCnameRecordRequest : UpdateRecordRequest
    {
        public UpdateCnameRecordRequest(long domainId, long recordId, string name, string host, int? ttl = null)
           : base(domainId, recordId, name)
        {
            Host = host ?? throw new ArgumentNullException(nameof(host));
            Ttl = ttl;
        }

        [JsonIgnore]
        public override RecordType Type => RecordType.CNAME;

        public string Host { get; }
    }
}