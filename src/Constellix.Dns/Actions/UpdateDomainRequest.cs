using System.Runtime.Serialization;

namespace Constellix.Dns
{
    public class UpdateDomainRequest
    {
        [IgnoreDataMember]
        public long Id { get; set; }

        [DataMember(Name = "soa", EmitDefaultValue = false)]
        public Soa Soa { get; set; }

        [DataMember(Name = "vanityNameServer", EmitDefaultValue = false)]
        public long VanityNameServer { get; set; }


        // NAME...
    }

}