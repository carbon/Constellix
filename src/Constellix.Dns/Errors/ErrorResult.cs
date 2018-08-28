using System.Runtime.Serialization;

namespace Constellix.Dns
{
    public class ErrorResult
    {
        [DataMember(Name = "errors")]
        public string[] Errors { get; set; }
    }
}

// {"errors":["Record not found"]}