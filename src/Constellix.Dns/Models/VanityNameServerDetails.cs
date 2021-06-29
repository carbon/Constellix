#nullable disable

namespace Constellix.Dns
{
    public sealed class VanityNameServerDetails
    {
        public long Id { get; init; }

        public string Name { get; init; }

        public bool IsDefault { get; init; }

        public bool IsPublic { get; init; }

        public string[] NameServers { get; init; }

        public long NameserverGroup { get; init; }

        public string NameserverGroupName { get; init; }

        public string NameserversListString { get; init; }
    }
}