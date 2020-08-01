using System.Text.Json;
using Xunit;

namespace Constellix.Dns.Tests
{
    public class ErrorResultTests
    {
        [Fact]
        public void Parse()
        {
            var text = @"{""errors"":[""Record not found""]}";

            var result = JsonSerializer.Deserialize<ErrorResult>(text, JsonHelper.Options);

            Assert.Equal("Record not found", result.Errors[0]);

        }
    }
}