#nullable disable

namespace Constellix.Dns
{
    public sealed class VanityNameServerDetails
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public bool IsDefault { get; set; }

        public bool IsPublic { get; set; }

        public string[] NameServers { get; set; }

        public long NameserverGroup { get; set; }

        public string NameserverGroupName { get; set; }

        public string NameserversListString { get; set; }
    }
}
 