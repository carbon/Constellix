#nullable disable

using System;

namespace Constellix.Dns
{
    public sealed class ANameRecordValue
    {
        public ANameRecordValue() { }

        public ANameRecordValue(string value, bool? disableFlag = null)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
            DisableFlag = disableFlag;
        }

        public string Value { get; init; }

        public bool? DisableFlag { get; init; }
        
        public static implicit operator ANameRecordValue(string value)
        {
            return new ANameRecordValue(value);
        }
    }
}