using System;

namespace Constellix.Dns
{
    public class RecordNotFoundException : Exception
    {
        public RecordNotFoundException(RecordType type, long recordId)
            : base(type.ToString() + "#" + recordId + " was not found") { }
    }
}