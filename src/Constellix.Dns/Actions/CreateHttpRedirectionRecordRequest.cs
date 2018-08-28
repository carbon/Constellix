﻿using System.Runtime.Serialization;

namespace Constellix.Dns
{
    public class CreateHttpRedirectionRecordRequest : CreateRecordRequest
    {
        public CreateHttpRedirectionRecordRequest(long domainId, string name, string url, int ttl = 3600)
            : base(domainId, name, ttl)
        {
            Url = url;
            RedirectTypeId = 301;
        }

        [IgnoreDataMember]
        public override RecordType Type => RecordType.HTTPRedirection;

        [DataMember(Name = "url")]
        public string Url { get; set; }

        // 1 = HiddenFrameMasked
        // 2 = 301 Redirect
        // 3 = 302 Redirect
        [DataMember(Name = "redirectTypeId")]
        public int RedirectTypeId { get; set; }

    }
}