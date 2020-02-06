#nullable disable

using System.Runtime.Serialization;

namespace Constellix.Dns
{
    public class Soa
    {        
        [DataMember(Name = "primaryNameserver")]
        public string PrimaryNameserver { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }
        
        [DataMember(Name = "ttl")]
        public int Ttl { get; set; }

        [DataMember(Name = "serial")]
        public int Serial { get; set; }

        [DataMember(Name = "refresh")]
        public int Refresh { get; set; }

        [DataMember(Name = "retry")]
        public int Retry { get; set; }

        [DataMember(Name = "expire")]
        public int Expire { get; set; }

        [DataMember(Name = "negCache")]
        public int NegCache { get; set; }
    }

}