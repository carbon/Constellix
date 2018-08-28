using Carbon.Json;
using Xunit;

namespace Constellix.Dns.Tests
{
    public class ErrorResultTests
    {
        [Fact]
        public void Parse()
        {
            var text = @"{""errors"":[""Record not found""]}";

            var result = JsonObject.Parse(text).As<ErrorResult>();

            Assert.Equal("Record not found", result.Errors[0]);

        }
    }
}