using System.Runtime.Serialization;

namespace Constellix.Dns
{
    public abstract class CreateRecordRequest
    {
        public CreateRecordRequest(long domainId, string name, int ttl)
        {
            DomainId = domainId;
            Name = name;
            Ttl = ttl;
        }

        [IgnoreDataMember]
        public long DomainId { get; }

        [DataMember(Name = "name")]
        public string Name { get; }

        [DataMember(Name = "ttl", EmitDefaultValue = false)]
        public int Ttl { get; }
       
        [IgnoreDataMember]
        public abstract RecordType Type { get; }
    }


    public class CreateCnameRecordRequest : CreateRecordRequest
    {
        public CreateCnameRecordRequest(long domainId, string name, string host, int ttl = 3600)
           : base(domainId, name, ttl)
        {
            Host = host;
        }

        public override RecordType Type => RecordType.CNAME;

        [DataMember(Name = "host")]
        public string Host { get; set; }

    }

    public class CreateANameRecordRequest : CreateRecordRequest
    {
        public CreateANameRecordRequest(long domainId, string name, int ttl = 3600, params ANameRecordValue[] values)
            : base(domainId, name, ttl)
        {
            RoundRobin = values;
        }

        public override RecordType Type => RecordType.ANAME;

        [DataMember(Name = "roundRobin")]
        public ANameRecordValue[] RoundRobin { get; }

    }


    /*
    public class CreateHttpRedirectionRecordRequest : CreateRecordRequest
    {
        public CreateHttpRedirectionRecordRequest(long domainId, string name, string url, int ttl = 3600)
            : base(domainId, name, ttl)
        {
            RoundRobin = values;
        }

        public override RecordType Type => RecordType.REdirect;

        [DataMember(Name = "roundRobin")]
        public ANameRecordValue[] RoundRobin { get; }

    }
    */

    // https://api-dns-docs.constellix.com/
}
