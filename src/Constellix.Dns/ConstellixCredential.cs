using System;
using System.Text;
using System.Threading.Tasks;

namespace Constellix.Dns
{
    public sealed class ConstellixCredential : IConstellixCredential
    {
        public ConstellixCredential(string apiKey, string secretKey)
        {
            ApiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            SecretKey = Encoding.UTF8.GetBytes(secretKey);
        }

        public bool ShouldRenew => false;

        public ValueTask RenewAsync()
        {
            return new ValueTask();
        }

        public string ApiKey { get; }

        public byte[] SecretKey { get; }
    }
}

// ref: https://api-dns-docs.constellix.com/