using System.Text.Json;

using Xunit;

namespace Constellix.Dns.Tests
{
    public class CreateDomainResultTests
    {
        [Fact]
        public void A()
        {
            var text = @"[
  {
    ""id"": 16046,
    ""name"": ""sampledomain1.com""
  },
  {
    ""id"": 16047,
    ""name"": ""sampledomain2.com""
  }
]";

            var result = JsonSerializer.Deserialize<CreateDomainResult[]>(text, JsonHelper.Options);

            Assert.Equal(16046, result[0].Id);
            Assert.Equal(16047, result[1].Id);
        }
    }
}
