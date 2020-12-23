﻿#nullable disable

using System;
using System.Text.Json.Serialization;

namespace Constellix.Dns
{
    public sealed class MXRecordValue
    {
        public MXRecordValue() { }

        public MXRecordValue(string value, int level, bool disableFlag = false)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
            Level = level;
            DisableFlag = disableFlag;
        }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("level")]
        public int Level { get; set; }

        [JsonPropertyName("disableFlag")]
        public bool? DisableFlag { get; set; }
    }
}