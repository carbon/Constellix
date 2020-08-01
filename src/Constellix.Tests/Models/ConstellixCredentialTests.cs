using Xunit;

namespace Constellix.Dns.Tests
{
    public class ConstellixCredentialTests
    {
        [Fact]
        public void Construct()
        {
            var credential = new ConstellixCredential("key", "secret");

            Assert.Equal("key", credential.ApiKey);
            Assert.Equal(6, credential.SecretKey.Length);

            Assert.False(credential.ShouldRenew);

        }
    }
}