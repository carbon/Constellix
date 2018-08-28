using System;
using System.Runtime.Serialization;

namespace Constellix.Dns
{
    public sealed class UpdateCnameRecordRequest : UpdateRecordRequest
    {
        public UpdateCnameRecordRequest(long domainId, long recordId, string name, string host)
           : base(domainId, recordId, name)
        {
            Host = host ?? throw new ArgumentNullException(nameof(host));
        }

        [IgnoreDataMember]
        public override RecordType Type => RecordType.CNAME;

        [DataMember(Name = "host")]
        public string Host { get; }
    }
}