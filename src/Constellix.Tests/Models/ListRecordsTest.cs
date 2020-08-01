using System.Text.Json;
using Xunit;

namespace Constellix.Dns.Tests
{
    public class ListRecordsTest
    {
        [Fact]
        public void A()
        {
            var json = @"[
  {
    ""id"": 2,
    ""type"": ""A"",
    ""recordType"": ""a"",
    ""name"": """",
    ""recordOption"": ""roundRobin"",
    ""noAnswer"": false,
    ""note"": """",
    ""ttl"": 1800,
    ""gtdRegion"": 1,
    ""parentId"": 16075,
    ""parent"": ""domain"",
    ""source"": ""Domain"",
    ""modifiedTs"": 1506320749881,
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
    ""roundRobinFailover"": [],
    ""pools"": [],
    ""poolsDetail"": []
},
  {
    ""id"": 2,
    ""type"": ""AAAA"",
    ""recordType"": ""aaaa"",
    ""name"": ""failoverrecord"",
    ""recordOption"": ""failover"",
    ""noAnswer"": false,
    ""note"": """",
    ""ttl"": 1800,
    ""gtdRegion"": 1,
    ""parentId"": 16075,
    ""parent"": ""domain"",
    ""source"": ""Domain"",
    ""modifiedTs"": 1506324045278,
    ""value"": [],
    ""roundRobin"": [],
    ""geolocation"": null,
    ""recordFailover"": {
      ""disabled"": false,
      ""failoverType"": 1,
      ""failoverTypeStr"": ""Normal (always lowest level)"",
      ""values"": [
        {
          ""value"": ""0:0:0:0:0:0:0:6"",
          ""disableFlag"": false,
          ""failedFlag"": false,
          ""status"": ""N/A"",
          ""sortOrder"": 1,
          ""markedActive"": true
        },
        {
          ""value"": ""0:0:0:0:0:0:0:4"",
          ""disableFlag"": false,
          ""failedFlag"": false,
          ""status"": ""N/A"",
          ""sortOrder"": 2,
          ""markedActive"": false
        }
      ]
    },
    ""failover"": {
      ""disabled"": false,
      ""failoverType"": 1,
      ""failoverTypeStr"": ""Normal (always lowest level)"",
      ""values"": [
        {
          ""value"": ""0:0:0:0:0:0:0:6"",
          ""disableFlag"": false,
          ""failedFlag"": false,
          ""status"": ""N/A"",
          ""sortOrder"": 1,
          ""markedActive"": true
        },
        {
          ""value"": ""0:0:0:0:0:0:0:4"",
          ""disableFlag"": false,
          ""failedFlag"": false,
          ""status"": ""N/A"",
          ""sortOrder"": 2,
          ""markedActive"": false
        }
      ]
    },
    ""pools"": [],
    ""poolsDetail"": [],
    ""roundRobinFailover"": [],
    ""contactIds"": null
  },
  {
    ""id"": 3,
    ""type"": ""CNAME"",
    ""recordType"": ""cname"",
    ""name"": ""failoverrecord1"",
    ""recordOption"": ""failover"",
    ""noAnswer"": false,
    ""note"": """",
    ""ttl"": 1800,
    ""gtdRegion"": 1,
    ""parentId"": 16075,
    ""parent"": ""domain"",
    ""source"": ""Domain"",
    ""modifiedTs"": 1506327519522,
    ""value"": """",
    ""roundRobin"": [],
    ""recordFailover"": {
      ""disabled"": false,
      ""failoverType"": 1,
      ""failoverTypeStr"": ""Normal (always lowest level)"",
      ""values"": [
        {
          ""id"": null,
          ""value"": ""www."",
          ""disableFlag"": false,
          ""failedFlag"": false,
          ""status"": ""N/A"",
          ""sortOrder"": 1,
          ""markedActive"": true
        },
        {
          ""id"": null,
          ""value"": ""www"",
          ""disableFlag"": false,
          ""failedFlag"": false,
          ""status"": ""N/A"",
          ""sortOrder"": 2,
          ""markedActive"": false
        }
      ]
    },
    ""failover"": {
      ""disabled"": false,
      ""failoverType"": 1,
      ""failoverTypeStr"": ""Normal (always lowest level)"",
      ""values"": [
        {
          ""id"": null,
          ""value"": ""www."",
          ""disableFlag"": false,
          ""failedFlag"": false,
          ""status"": ""N/A"",
          ""sortOrder"": 1,
          ""markedActive"": true
        },
        {
          ""id"": null,
          ""value"": ""www"",
          ""disableFlag"": false,
          ""failedFlag"": false,
          ""status"": ""N/A"",
          ""sortOrder"": 2,
          ""markedActive"": false
        }
      ]
    },
    ""pools"": [],
    ""poolsDetail"": [],
    ""geolocation"": null,
    ""host"": """",
    ""contactIds"": null
  },
  {
    ""id"": 3,
    ""type"": ""AAAA"",
    ""recordType"": ""aaaa"",
    ""name"": ""poolrecord"",
    ""recordOption"": ""pools"",
    ""noAnswer"": false,
    ""note"": """",
    ""ttl"": 1800,
    ""gtdRegion"": 1,
    ""parentId"": 16075,
    ""parent"": ""domain"",
    ""source"": ""Domain"",
    ""modifiedTs"": 1506324214727,
    ""value"": [],
    ""roundRobin"": [],
    ""geolocation"": null,
    ""pools"": [
      508,
      516
    ],
    ""poolsDetail"": [
      {
        ""id"": 508,
        ""name"": ""pool_764""
      },
      {
        ""id"": 516,
        ""name"": ""pool_931""
      }
    ],
    ""roundRobinFailover"": []
  },
  {
    ""id"": 2,
    ""type"": ""CNAME"",
    ""recordType"": ""cname"",
    ""name"": ""poolsrecord"",
    ""recordOption"": ""pools"",
    ""noAnswer"": false,
    ""note"": """",
    ""ttl"": 1800,
    ""gtdRegion"": 1,
    ""parentId"": 16075,
    ""parent"": ""domain"",
    ""source"": ""Domain"",
    ""modifiedTs"": 1506327347894,
    ""value"": """",
    ""roundRobin"": [],
    ""pools"": [
      230
    ],
    ""poolsDetail"": [
      {
        ""id"": 230,
        ""name"": ""bigpool""
      }
    ],
    ""geolocation"": null,
    ""host"": """"
  },
  {
    ""id"": 1,
    ""type"": ""A"",
    ""recordType"": ""a"",
    ""name"": ""roundrobinfailoveredit"",
    ""recordOption"": ""roundRobinFailover"",
    ""noAnswer"": false,
    ""note"": """",
    ""ttl"": 1800,
    ""gtdRegion"": 1,
    ""parentId"": 16075,
    ""parent"": ""domain"",
    ""source"": ""Domain"",
    ""modifiedTs"": 1506319468721,
    ""value"": [
      ""15.45.25.23"",
      ""154.45.25.24""
    ],
    ""roundRobin"": [],
    ""geolocation"": null,
    ""roundRobinFailover"": [
      {
        ""value"": ""15.45.25.23"",
        ""disableFlag"": false,
        ""failedFlag"": false,
        ""status"": ""N/A"",
        ""sortOrder"": 1,
        ""markedActive"": false
      },
      {
        ""value"": ""154.45.25.24"",
        ""disableFlag"": false,
        ""failedFlag"": false,
        ""status"": ""N/A"",
        ""sortOrder"": 2,
        ""markedActive"": false
      }
    ],
    ""pools"": [],
    ""poolsDetail"": [],
    ""contactIds"": null
  },
  {
    ""id"": 4,
    ""type"": ""AAAA"",
    ""recordType"": ""aaaa"",
    ""name"": ""roundrobinfailoverrecord"",
    ""recordOption"": ""roundRobinFailover"",
    ""noAnswer"": false,
    ""note"": """",
    ""ttl"": 1800,
    ""gtdRegion"": 1,
    ""parentId"": 16075,
    ""parent"": ""domain"",
    ""source"": ""Domain"",
    ""modifiedTs"": 1506324291663,
    ""value"": [
      ""0:0:0:0:0:0:0:6"",
      ""0:0:0:0:0:0:0:4""
    ],
    ""roundRobin"": [],
    ""geolocation"": null,
    ""pools"": [],
    ""poolsDetail"": [],
    ""roundRobinFailover"": [
      {
        ""value"": ""0:0:0:0:0:0:0:6"",
        ""disableFlag"": false,
        ""failedFlag"": false,
        ""status"": ""N/A"",
        ""sortOrder"": 1,
        ""markedActive"": false
      },
      {
        ""value"": ""0:0:0:0:0:0:0:4"",
        ""disableFlag"": false,
        ""failedFlag"": false,
        ""status"": ""N/A"",
        ""sortOrder"": 2,
        ""markedActive"": false
      }
    ],
    ""contactIds"": null
  },
  {
    ""id"": 1,
    ""type"": ""HTTPRedirection"",
    ""recordType"": ""httpredirection"",
    ""name"": ""sr_http_redirection"",
    ""recordOption"": ""roundRobin"",
    ""noAnswer"": false,
    ""note"": ""Http redirection standard record"",
    ""ttl"": 1800,
    ""gtdRegion"": 1,
    ""parentId"": 16075,
    ""parent"": ""domain"",
    ""source"": ""Domain"",
    ""modifiedTs"": 1506332303447,
    ""value"": ""http://www.google.com"",
    ""roundRobin"": [
      {
        ""value"": ""http://www.google.com""
      }
    ],
    ""title"": ""http redirection automation"",
    ""keywords"": ""automation  http redirection"",
    ""description"": ""it will redirect test domain."",
    ""hardlinkFlag"": false,
    ""redirectTypeId"": 2,
    ""url"": ""http://www.google.com""
  },
  {
    ""id"": 1,
    ""type"": ""ANAME"",
    ""recordType"": ""aname"",
    ""name"": ""standardrecordedit"",
    ""recordOption"": ""roundRobin"",
    ""noAnswer"": false,
    ""note"": """",
    ""ttl"": 1800,
    ""gtdRegion"": 1,
    ""parentId"": 16075,
    ""parent"": ""domain"",
    ""source"": ""Domain"",
    ""modifiedTs"": 1506332773982,
    ""value"": [
      {
        ""value"": ""www.google.com."",
        ""disableFlag"": false
      }
    ],
    ""roundRobin"": [
      {
        ""value"": ""www.google.com."",
        ""disableFlag"": false
      }
    ],
    ""recordFailover"": {
      ""disabled"": false,
      ""failoverType"": 1,
      ""failoverTypeStr"": ""Normal (always lowest level)"",
      ""values"": []
    },
    ""failover"": {
      ""disabled"": false,
      ""failoverType"": 1,
      ""failoverTypeStr"": ""Normal (always lowest level)"",
      ""values"": []
    }
  },
  {
    ""id"": 1,
    ""type"": ""MX"",
    ""recordType"": ""mx"",
    ""name"": ""standardrecordmxedit"",
    ""recordOption"": ""roundRobin"",
    ""noAnswer"": false,
    ""note"": """",
    ""ttl"": 1800,
    ""gtdRegion"": 1,
    ""parentId"": 16075,
    ""parent"": ""domain"",
    ""source"": ""Domain"",
    ""modifiedTs"": 1506336638893,
    ""value"": [
      {
        ""value"": ""domainDocument."",
        ""level"": 300,
        ""disableFlag"": false
      }
    ],
    ""roundRobin"": [
      {
        ""value"": ""domainDocument."",
        ""level"": 300,
        ""disableFlag"": false
      }
    ]
  },
  {
    ""id"": 4,
    ""type"": ""CNAME"",
    ""recordType"": ""cname"",
    ""name"": ""standardrecordwithgeoip"",
    ""recordOption"": ""roundRobin"",
    ""noAnswer"": false,
    ""note"": """",
    ""ttl"": 1800,
    ""gtdRegion"": 1,
    ""parentId"": 16075,
    ""parent"": ""domain"",
    ""source"": ""Domain"",
    ""modifiedTs"": 1506327732286,
    ""value"": ""www."",
    ""roundRobin"": [
      {
        ""value"": ""www."",
        ""disableFlag"": false
      }
    ],
    ""pools"": [],
    ""poolsDetail"": [],
    ""geolocation"": {
      ""geoipFilter"": 1,
      ""geoipFilterDetail"": {
        ""id"": 1,
        ""name"": ""World (Default)""
      },
      ""drop"": false
    },
    ""host"": ""www.""
  },
  {
    ""id"": 5,
    ""type"": ""AAAA"",
    ""recordType"": ""aaaa"",
    ""name"": ""standardrecordwithgeolocation"",
    ""recordOption"": ""roundRobin"",
    ""noAnswer"": false,
    ""note"": """",
    ""ttl"": 1800,
    ""gtdRegion"": 1,
    ""parentId"": 16075,
    ""parent"": ""domain"",
    ""source"": ""Domain"",
    ""modifiedTs"": 1506324422065,
    ""value"": [
      ""0:0:0:0:0:0:0:6""
    ],
    ""roundRobin"": [
      {
        ""value"": ""0:0:0:0:0:0:0:6"",
        ""disableFlag"": false
      }
    ],
    ""geolocation"": {
      ""geoipFilter"": 1,
      ""geoipFilterDetail"": {
        ""id"": 1,
        ""name"": ""World (Default)""
      },
      ""drop"": false
    },
    ""pools"": [],
    ""poolsDetail"": [],
    ""roundRobinFailover"": []
  },
  {
    ""id"": 6,
    ""type"": ""A"",
    ""recordType"": ""a"",
    ""name"": ""standardrecordwithgeolocation"",
    ""recordOption"": ""roundRobin"",
    ""noAnswer"": false,
    ""note"": """",
    ""ttl"": 1800,
    ""gtdRegion"": 1,
    ""parentId"": 16075,
    ""parent"": ""domain"",
    ""source"": ""Domain"",
    ""modifiedTs"": 1506321602781,
    ""value"": [
      ""15.45.25.35""
    ],
    ""roundRobin"": [
      {
        ""value"": ""15.45.25.35"",
        ""disableFlag"": false
      }
    ],
    ""geolocation"": {
      ""geoipFilter"": 1,
      ""geoipFilterDetail"": {
        ""id"": 1,
        ""name"": ""World (Default)""
      },
      ""drop"": false
    },
    ""roundRobinFailover"": [],
    ""pools"": [],
    ""poolsDetail"": []
  },
  {
    ""id"": 5,
    ""type"": ""CNAME"",
    ""recordType"": ""cname"",
    ""name"": ""standardrecordwithgeoproximity"",
    ""recordOption"": ""roundRobin"",
    ""noAnswer"": false,
    ""note"": """",
    ""ttl"": 1800,
    ""gtdRegion"": 1,
    ""parentId"": 16075,
    ""parent"": ""domain"",
    ""source"": ""Domain"",
    ""modifiedTs"": 1506327843521,
    ""value"": ""www."",
    ""roundRobin"": [
      {
        ""value"": ""www."",
        ""disableFlag"": false
      }
    ],
    ""pools"": [],
    ""poolsDetail"": [],
    ""geolocation"": {
      ""drop"": false,
      ""geoipProximity"": 686,
      ""geoipProximityDetail"": {
        ""id"": 686,
        ""name"": ""Annaba""
      }
    },
    ""host"": ""www.""
  },
  {
    ""id"": 6,
    ""type"": ""AAAA"",
    ""recordType"": ""aaaa"",
    ""name"": ""standardwithgeoiproximity"",
    ""recordOption"": ""roundRobin"",
    ""noAnswer"": false,
    ""note"": """",
    ""ttl"": 1800,
    ""gtdRegion"": 1,
    ""parentId"": 16075,
    ""parent"": ""domain"",
    ""source"": ""Domain"",
    ""modifiedTs"": 1506324461049,
    ""value"": [
      ""0:0:0:0:0:0:0:6""
    ],
    ""roundRobin"": [
      {
        ""value"": ""0:0:0:0:0:0:0:6"",
        ""disableFlag"": false
      }
    ],
    ""geolocation"": {
      ""drop"": false,
      ""geoipProximity"": 686,
      ""geoipProximityDetail"": {
        ""id"": 686,
        ""name"": ""Annaba""
      }
    },
    ""pools"": [],
    ""poolsDetail"": [],
    ""roundRobinFailover"": []
  },
  {
    ""id"": 5,
    ""type"": ""A"",
    ""recordType"": ""a"",
    ""name"": ""standardwithgeoiproximity"",
    ""recordOption"": ""roundRobin"",
    ""noAnswer"": false,
    ""note"": """",
    ""ttl"": 1800,
    ""gtdRegion"": 1,
    ""parentId"": 16075,
    ""parent"": ""domain"",
    ""source"": ""Domain"",
    ""modifiedTs"": 1506321976404,
    ""value"": [
      ""15.45.25.35""
    ],
    ""roundRobin"": [
      {
        ""value"": ""15.45.25.35"",
        ""disableFlag"": false
      }
    ],
    ""geolocation"": {
      ""geoipFilter"": 1,
      ""geoipFilterDetail"": {
        ""id"": 1,
        ""name"": ""World (Default)""
      },
      ""drop"": false
    },
    ""roundRobinFailover"": [],
    ""pools"": [],
    ""poolsDetail"": []
  },
  {
    ""id"": 7,
    ""type"": ""A"",
    ""recordType"": ""a"",
    ""name"": ""standardwithgeoiproximity"",
    ""recordOption"": ""roundRobin"",
    ""noAnswer"": false,
    ""note"": """",
    ""ttl"": 1800,
    ""gtdRegion"": 1,
    ""parentId"": 16075,
    ""parent"": ""domain"",
    ""source"": ""Domain"",
    ""modifiedTs"": 1506321976395,
    ""value"": [
      ""15.45.25.35""
    ],
    ""roundRobin"": [
      {
        ""value"": ""15.45.25.35"",
        ""disableFlag"": false
      }
    ],
    ""geolocation"": {
      ""drop"": false,
      ""geoipProximity"": 686,
      ""geoipProximityDetail"": {
        ""id"": 686,
        ""name"": ""Annaba""
      }
    },
    ""roundRobinFailover"": [],
    ""pools"": [],
    ""poolsDetail"": []
  },
  {
    ""id"": 8,
    ""type"": ""A"",
    ""recordType"": ""a"",
    ""name"": ""standardwithgeoiproximity1"",
    ""recordOption"": ""roundRobin"",
    ""noAnswer"": false,
    ""note"": """",
    ""ttl"": 1800,
    ""gtdRegion"": 1,
    ""parentId"": 16075,
    ""parent"": ""domain"",
    ""source"": ""Domain"",
    ""modifiedTs"": 1506322433545,
    ""value"": [
      ""15.45.25.35""
    ],
    ""roundRobin"": [
      {
        ""value"": ""15.45.25.35"",
        ""disableFlag"": false
      }
    ],
    ""geolocation"": {
      ""drop"": false,
      ""geoipProximity"": 686,
      ""geoipProximityDetail"": {
        ""id"": 686,
        ""name"": ""Annaba""
      }
    },
    ""roundRobinFailover"": [],
    ""pools"": [],
    ""poolsDetail"": []
  },
  {
    ""id"": 3,
    ""type"": ""A"",
    ""recordType"": ""a"",
    ""name"": ""test"",
    ""recordOption"": ""roundRobin"",
    ""noAnswer"": false,
    ""note"": """",
    ""ttl"": 1800,
    ""gtdRegion"": 1,
    ""parentId"": 16075,
    ""parent"": ""domain"",
    ""source"": ""Domain"",
    ""modifiedTs"": 1506321276616,
    ""value"": [
      ""15.45.25.35""
    ],
    ""roundRobin"": [
      {
        ""value"": ""15.45.25.35"",
        ""disableFlag"": false
      }
    ],
    ""geolocation"": {
      ""drop"": false,
      ""geoipProximity"": 686,
      ""geoipProximityDetail"": {
        ""id"": 686,
        ""name"": ""Annaba""
      }
    },
    ""recordFailover"": {
      ""disabled"": false,
      ""failoverType"": 1,
      ""failoverTypeStr"": ""Normal (always lowest level)"",
      ""values"": []
    },
    ""failover"": {
      ""disabled"": false,
      ""failoverType"": 1,
      ""failoverTypeStr"": ""Normal (always lowest level)"",
      ""values"": []
    },
    ""roundRobinFailover"": [],
    ""pools"": [],
    ""poolsDetail"": []
  },
  {
    ""id"": 1,
    ""type"": ""NAPTR"",
    ""recordType"": ""naptr"",
    ""name"": ""test"",
    ""recordOption"": ""roundRobin"",
    ""noAnswer"": false,
    ""note"": """",
    ""ttl"": 1800,
    ""gtdRegion"": 1,
    ""parentId"": 16075,
    ""parent"": ""domain"",
    ""source"": ""Domain"",
    ""modifiedTs"": 1506337648319,
    ""value"": [
      {
        ""order"": 10,
        ""preference"": 100,
        ""flags"": ""s"",
        ""service"": """",
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
        ""service"": """",
        ""regularExpression"": """",
        ""replacement"": ""foo.example.com."",
        ""disableFlag"": false
      }
    ]
  },
  {
    ""id"": 4,
    ""type"": ""A"",
    ""recordType"": ""a"",
    ""name"": ""test1"",
    ""recordOption"": ""roundRobin"",
    ""noAnswer"": false,
    ""note"": """",
    ""ttl"": 1800,
    ""gtdRegion"": 1,
    ""parentId"": 16075,
    ""parent"": ""domain"",
    ""source"": ""Domain"",
    ""modifiedTs"": 1506321234391,
    ""value"": [
      ""15.45.25.35""
    ],
    ""roundRobin"": [
      {
        ""value"": ""15.45.25.35"",
        ""disableFlag"": false
      }
    ],
    ""geolocation"": {
      ""geoipFilter"": 1,
      ""geoipFilterDetail"": {
        ""id"": 1,
        ""name"": ""World (Default)""
      },
      ""drop"": false
    },
    ""recordFailover"": {
      ""disabled"": false,
      ""failoverType"": 1,
      ""failoverTypeStr"": ""Normal (always lowest level)"",
      ""values"": []
    },
    ""failover"": {
      ""disabled"": false,
      ""failoverType"": 1,
      ""failoverTypeStr"": ""Normal (always lowest level)"",
      ""values"": []
    },
    ""roundRobinFailover"": [],
    ""pools"": [],
    ""poolsDetail"": []
  }
]";


            var records = JsonSerializer.Deserialize<Record[]>(json, JsonHelper.Options);

            var record_0 = records[0];

            Assert.Equal(RecordType.A, record_0.Type);

            var last = records[20]; // 21 total

            Assert.Equal(1800, last.Ttl);

            Assert.Equal("15.45.25.35", JsonSerializer.Deserialize<ARecordValue>(last.RoundRobin[0].GetRawText(), JsonHelper.Options).Value);
        }
    }
}
