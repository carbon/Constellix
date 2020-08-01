using System.Text.Json;

using Xunit;

namespace Constellix.Dns.Tests
{
    public class ListDomainsTests
    {
        [Fact]
        public void Test1()
        {
            var text = @"[
  {
    ""id"": 15590,
    ""name"": ""sampledomain.com"",
    ""soa"": {
      ""primaryNameserver"": ""ns0.constellix.com."",
      ""email"": ""dns.constellix.com."",
      ""ttl"": 86400,
      ""serial"": 2015010196,
      ""refresh"": 43200,
      ""retry"": 3600,
      ""expire"": 1209600,
      ""negCache"": 180
    },
    ""createdTs"": ""2017-08-11T14:41:44Z"",
    ""modifiedTs"": ""2017-09-18T14:51:58Z"",
    ""typeId"": 1,
    ""domainTags"": [],
    ""folder"": null,
    ""hasGtdRegions"": true,
    ""hasGeoIP"": false,
    ""nameserverGroup"": 1,
    ""nameservers"": [
      ""ns1.constellix.com."",
      ""ns2.constellix.com."",
      ""ns3.constellix.com."",
      ""ns4.constellix.com.""
    ],
    ""note"": """",
    ""version"": 27,
    ""status"": ""ACTIVE"",
    ""tags"": null
  },
  {
    ""id"": 15966,
    ""name"": ""sampledomain1.com"",
    ""soa"": {
      ""primaryNameserver"": ""ns0.constellix.com."",
      ""email"": ""dns.constellix.com."",
      ""ttl"": 86400,
      ""serial"": 2015010107,
      ""refresh"": 43200,
      ""retry"": 3600,
      ""expire"": 1209600,
      ""negCache"": 180
    },
    ""createdTs"": ""2017-09-18T13:57:21Z"",
    ""modifiedTs"": ""2017-09-18T14:51:30Z"",
    ""typeId"": 1,
    ""domainTags"": [],
    ""folder"": null,
    ""hasGtdRegions"": false,
    ""hasGeoIP"": false,
    ""nameserverGroup"": 1,
    ""nameservers"": [
      ""ns1.constellix.com."",
      ""ns2.constellix.com."",
      ""ns3.constellix.com."",
      ""ns4.constellix.com.""
    ],
    ""note"": """",
    ""version"": 6,
    ""status"": ""ACTIVE"",
    ""tags"": null
  },
  {
    ""id"": 14739,
    ""name"": ""domain.secondary.user"",
    ""soa"": {
      ""primaryNameserver"": ""ns0.constellix.com."",
      ""email"": ""dns.constellix.com."",
      ""ttl"": 86400,
      ""serial"": 2015016478,
      ""refresh"": 43200,
      ""retry"": 3600,
      ""expire"": 1209600,
      ""negCache"": 180
    },
    ""createdTs"": ""2017-07-04T11:55:36Z"",
    ""modifiedTs"": ""2017-09-18T13:50:07Z"",
    ""typeId"": 1,
    ""domainTags"": [],
    ""folder"": null,
    ""hasGtdRegions"": false,
    ""hasGeoIP"": false,
    ""nameserverGroup"": 1,
    ""nameservers"": [
      ""ns1.constellix.com."",
      ""ns2.constellix.com."",
      ""ns3.constellix.com."",
      ""ns4.constellix.com.""
    ],
    ""note"": ""pool \""Edit3133452498\"" updated  to version 2"",
    ""version"": 4,
    ""status"": ""ACTIVE"",
    ""tags"": null
  }
]";

            var nameservers = new[] { "ns1.constellix.com.", "ns2.constellix.com.", "ns3.constellix.com.", "ns4.constellix.com." };

            var domains = JsonSerializer.Deserialize<Domain[]>(text, JsonHelper.Options);

            Assert.Equal(3, domains.Length);

            var domain_2 = domains[2];

            Assert.Equal(14739,                     domain_2.Id);
            Assert.Equal("domain.secondary.user",   domain_2.Name);
            Assert.Equal(1,                         domain_2.TypeId);
            Assert.Equal("ACTIVE",                  domain_2.Status);
            Assert.Equal(86400,                     domain_2.Soa.Ttl);
            Assert.Equal(180,                       domain_2.Soa.NegCache);       
            Assert.Equal(nameservers,               domain_2.Nameservers);
            Assert.Equal(4,                         domain_2.Version);
            Assert.Equal(1499169336,                domain_2.CreatedTs.ToUnixTimeSeconds());
            Assert.Equal(1505742607,                domain_2.ModifiedTs.ToUnixTimeSeconds());

            Assert.Null(domain_2.Tags);
            
            Assert.Null(domains[1].Tags);
        }
    }
}