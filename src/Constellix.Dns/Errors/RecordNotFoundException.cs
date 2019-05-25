using System;

namespace Constellix.Dns
{
    public sealed class RecordNotFoundException : Exception
    {
        public RecordNotFoundException(RecordType type, long recordId)
            : base("constellix:records/" + type.ToString() + "/" + recordId + " was not found") { }
    }
}