using System.Threading.Tasks;

namespace Constellix.Dns
{
    public interface IConstellixCredential
    {
        bool ShouldRenew { get; }

        ValueTask RenewAsync();

        string ApiKey { get; }

        // plaintext as UTF8
        byte[] SecretKey { get; }
    }
}

// ref: https://api-dns-docs.constellix.com/