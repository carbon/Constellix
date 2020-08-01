using Xunit;

using System.Text.Json;

namespace Constellix.Dns.Tests
{
    public class RecordTests
    {
        [Fact]
        public void A()
        {
            var text = @"{
    ""id"": 2,
    ""type"": ""A"",
    ""recordType"": ""a"",
    ""name"": ""standardrecordwithGTD"",
    ""recordOption"": ""roundRobin"",
    ""noAnswer"": false,
    ""note"": """",
    ""ttl"": 1800,
    ""gtdRegion"": 1,
    ""parentId"": 11,
    ""parent"": ""domain"",
    ""source"": ""Domain"",
    ""modifiedTs"": 1506083484099,
    ""value"": [
      ""15.45.25.35""
    ],
    ""roundRobin"": [
      {
        ""value"": ""15.45.25.35"",
        ""disableFlag"": false
      }
    ],
    ""geolocation"": null,
    ""roundRobinFailover"": null
  }";


            var record = JsonSerializer.Deserialize<Record>(text, JsonHelper.Options);

            Assert.Equal(2, record.Id);
            Assert.Equal(RecordType.A, record.Type);
            Assert.Equal("a", record.RecordType);
            Assert.Equal("standardrecordwithGTD", record.Name);
            Assert.Equal(RecordOptions.RoundRobin, record.RecordOption);
            Assert.Equal(string.Empty, record.Note);
            Assert.Equal(1800, record.Ttl);
            Assert.Equal(1, record.GtdRegion);
            Assert.Equal(11, record.ParentId);
            Assert.Equal("domain", record.Parent);
            Assert.Equal("Domain", record.Source);
            Assert.Equal(1506083484099, record.ModifiedTs);
            
            // Assert.Equal(new[] { "15.45.25.35" }, record.Value.ToArrayOf<string>());

            Assert.False(record.NoAnswer);

        }

        [Fact]
        public void Mx()
        {
            var text = @"{
    ""id"": 1,
    ""type"": ""MX"",
    ""recordType"": ""mx"",
    ""name"": ""standardmxrecord"",
    ""recordOption"": ""roundRobin"",
    ""noAnswer"": false,
    ""note"": """",
    ""ttl"": 1800,
    ""gtdRegion"": 1,
    ""parentId"": 333,
    ""parent"": ""domain"",
    ""source"": ""Domain"",
    ""modifiedTs"": 1506336510499,
    ""value"": [
      {
        ""value"": ""domainDocument."",
        ""level"": 10,
        ""disableFlag"": false
      }
    ],
    ""roundRobin"": [
      {
        ""value"": ""domainDocument."",
        ""level"": 10,
        ""disableFlag"": false
      }
    ]
  }";

            var record = JsonSerializer.Deserialize<Record>(text, JsonHelper.Options);

            Assert.Equal(1, record.Id);
            Assert.Equal(RecordType.MX, record.Type);
            Assert.Equal(333, record.ParentId);
            Assert.Equal("domain", record.Parent);

        }



        [Fact]
        public void Naptr()
        {
            var json = @"{
  ""id"": 2,
  ""type"": ""NAPTR"",
  ""recordType"": ""naptr"",
  ""name"": ""standardnaptr"",
  ""recordOption"": ""roundRobin"",
  ""noAnswer"": false,
  ""note"": """",
  ""ttl"": 1800,
  ""gtdRegion"": 1,
  ""parentId"": 11,
  ""parent"": ""domain"",
  ""source"": ""Domain"",
  ""modifiedTs"": 1506337894316,
  ""value"": [
    {
      ""order"": 10,
      ""preference"": 100,
      ""flags"": ""s"",
      ""service"": ""SIP+D2U"",
      ""regularExpression"": """",
      ""replacement"": ""foo.example.com."",
      ""disableFlag"": false
    }
  ],
  ""roundRobin"": [
    {
      ""order"": 10,
      ""preference"": 100,
      ""flags"": ""s"",
      ""service"": ""SIP+D2U"",
      ""regularExpression"": """",
      ""replacement"": ""foo.example.com."",
      ""disableFlag"": false
    }
  ]
}";

            var record = JsonSerializer.Deserialize<Record>(json, JsonHelper.Options);

            Assert.Equal(2, record.Id);
            Assert.Equal(RecordType.NAPTR, record.Type);
            Assert.Equal(11, record.ParentId);
        }


        [Fact]
        public void Caa()
        {
            string text = @"{
    ""id"": 1,
    ""type"": ""CAA"",
    ""recordType"": ""caa"",
    ""name"": ""standardrecordcaa"",
    ""recordOption"": ""roundRobin"",
    ""noAnswer"": false,
    ""note"": """",
    ""ttl"": 1800,
    ""gtdRegion"": 1,
    ""parentId"": 11111,
    ""parent"": ""domain"",
    ""source"": ""Domain"",
    ""modifiedTs"": 1506341566234,
    ""value"": [
      {
        ""flag"": 0,
        ""tag"": ""issue"",
        ""data"": ""comodoca.com"",
        ""caaProviderId"": 3,
        ""disableFlag"": false
      }
    ],
    ""roundRobin"": [
      {
        ""flag"": 0,
        ""tag"": ""issue"",
        ""data"": ""comodoca.com"",
        ""caaProviderId"": 3,
        ""disableFlag"": false
      }
    ]
  }";

            var record = JsonSerializer.Deserialize<Record>(text, JsonHelper.Options);

            Assert.Equal(RecordType.CAA, record.Type);
            Assert.Equal("caa", record.RecordType);

            // var value = record.Value.ToArrayOf<CaaRecordValue>()[0];
            var values = JsonSerializer.Deserialize<CaaRecordValue[]>(record.RoundRobin.GetRawText(), JsonHelper.Options); 
            var value = values[0];

            Assert.Equal(0, value.Flag);
            Assert.Equal("issue", value.Tag);
            Assert.Equal("comodoca.com", value.Data);
            Assert.Equal(3, value.CaaProviderId);
        }

        [Fact]
        public void ParseArray()
        {
            var text = @"[
  {
    ""id"": 1,
    ""type"": ""CNAME"",
    ""recordType"": ""cname"",
    ""name"": ""www"",
    ""recordOption"": ""roundRobin"",
    ""noAnswer"": false,
    ""note"": """",
    ""ttl"": 3600,
    ""gtdRegion"": 1,
    ""parentId"": 434,
    ""parent"": ""domain"",
    ""source"": ""Domain"",
    ""modifiedTs"": 1518727652908,
    ""value"": ""test.com."",
    ""roundRobin"": [
      {
        ""value"": ""test.com."",
        ""disableFlag"": false
      }
    ],
    ""geolocation"": null,
    ""host"": ""test.com.""
  }
]";


            var records = JsonSerializer.Deserialize<Record[]>(text, JsonHelper.Options);

            var record = records[0];

            Assert.Equal(1, record.Id);
            Assert.Equal("test.com.", record.Host);
        }
    }


}