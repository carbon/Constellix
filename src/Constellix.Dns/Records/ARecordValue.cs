#nullable disable

using System;
using System.Text.Json.Serialization;

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

        [JsonPropertyName("value")]
        public string Value { get; init; }

        [JsonPropertyName("disableFlag")]
        public bool? DisableFlag { get; init; }
    }
}