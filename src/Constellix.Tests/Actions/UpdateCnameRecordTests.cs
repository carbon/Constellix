using System.Text.Json;

using Xunit;

namespace Constellix.Dns.Tests
{
    public class UpdateCnameRecordTests
    {
        [Fact]
        public void Serialize()
        {
            var request = new UpdateCnameRecordRequest(1, 2, "*", "test.com", ttl: 3600);

            Assert.Equal(@"{
  ""host"": ""test.com"",
  ""name"": ""*"",
  ""ttl"": 3600
}", JsonSerializer.Serialize(request, JsonHelper.Options));
        }

        [Fact]
        public void Serialize2_NoTtl()
        {
            var request = new UpdateCnameRecordRequest(1, 2, "*", "test.com");

            Assert.Equal(@"{
  ""host"": ""test.com"",
  ""name"": ""*""
}", JsonSerializer.Serialize(request, JsonHelper.Options));
        }
    }
}