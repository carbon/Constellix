using System;
using System.Runtime.Serialization;

namespace Constellix.Dns
{
    public sealed class CreateDomainRequest
    {
        public CreateDomainRequest(params string[] names)
        {
            Names = names ?? throw new ArgumentNullException(nameof(names));
        }

        [DataMember(Name = "names")]
        public string[] Names { get;  }
    }
}