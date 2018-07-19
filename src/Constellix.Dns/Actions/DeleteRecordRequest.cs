namespace Constellix.Dns
{
    public class DeleteRecordRequest
    {
        public DeleteRecordRequest(long domainId, RecordType type, long recordId)
        {
            DomainId = domainId;
            RecordType = type;
            RecordId = recordId;
        }

        public long DomainId { get; }

        public RecordType RecordType { get; }

        public long RecordId { get; }
    }
}
