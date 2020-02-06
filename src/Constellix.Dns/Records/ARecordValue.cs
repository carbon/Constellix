#nullable disable

using System;
using System.Runtime.Serialization;

namespace Constellix.Dns
{
    public sealed class ARecordValue
    {
        public ARecordValue() { }

        public ARecordValue(string value, bool disableFlag = false)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
            DisableFlag = disableFlag;
        }

        [DataMember(Name = "value")]
        public string Value { get; set; }

        [DataMember(Name = "disableFlag", EmitDefaultValue = false)]
        public bool DisableFlag { get; set; }
    }
}