using System.Text.Json.Serialization;

namespace Constellix.Dns
{
    public class UpdateDomainRequest
    {
        public UpdateDomainRequest() { }

        public UpdateDomainRequest(long id, Soa soa, long? vanityNameServer)
        {
            Id = id;
            Soa = soa;
            VanityNameServer = vanityNameServer;
        }

        [JsonIgnore]
        public long Id { get; set; }

        public Soa? Soa { get; set; }

        public long? VanityNameServer { get; set; }

        // NAME...
    }
}