using System.Text.Json;

using Xunit;

namespace Constellix.Dns.Tests
{
    public class UpdateAnameRecordTests
    {
        [Fact]
        public void Serialize()
        {
            var request = new UpdateAnameRecordRequest(1, 2, "www", "test.com");

            Assert.Equal(@"

{
  ""roundRobin"": [
    {
      ""value"": ""test.com""
    }
  ],
  ""name"": ""www""
}

".Trim(), JsonSerializer.Serialize(request, JsonHelper.Options));
        }
    }


}