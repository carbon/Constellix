using System;
using Carbon.Json;
using Xunit;

namespace Constellix.Dns
{
    public class CreateDomainResultTests
    {
        [Fact]
        public void Test()
        {
            throw new System.Exception(DateTimeOffset.FromUnixTimeMilliseconds(1489401874402).ToString());
        }

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

            var result = JsonNode.Parse(text).ToArrayOf<CreateDomainResult>();

            Assert.Equal(16046, result[0].Id);
            Assert.Equal(16047, result[1].Id);
        }
    }
}
