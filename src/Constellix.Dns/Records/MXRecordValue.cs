#nullable disable

using System;
using System.Runtime.Serialization;

namespace Constellix.Dns
{
    public class MXRecordValue
    {
        public MXRecordValue() { }

        public MXRecordValue(string value, int level, bool disableFlag = false)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
            Level = level;
            DisableFlag = disableFlag;
        }

        [DataMember(Name = "value")]
        public string Value { get; set; }

        [DataMember(Name = "level")]
        public int Level { get; set; }

        [DataMember(Name = "disableFlag", EmitDefaultValue = false)]
        public bool DisableFlag { get; set; }
    }
}