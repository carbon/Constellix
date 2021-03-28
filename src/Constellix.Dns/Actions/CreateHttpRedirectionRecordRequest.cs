using System.Text.Json.Serialization;

namespace Constellix.Dns
{
    public sealed class CreateHttpRedirectionRecordRequest : CreateRecordRequest
    {
        public CreateHttpRedirectionRecordRequest(long domainId, string name, string url, int ttl = 3600)
            : base(domainId, name, ttl)
        {
            Url = url;
            RedirectTypeId = 301;
        }

        [JsonIgnore]
        public override RecordType Type => RecordType.HTTPRedirection;

        public string Url { get; init; }

        // 1 = HiddenFrameMasked
        // 2 = 301 Redirect
        // 3 = 302 Redirect
        public int RedirectTypeId { get; init; }
    }
}
