namespace StudentInsight.DTOs.Common
{
    public abstract class BaseAuditDto : BaseDto
    {
        public DateTime CreatedAt { get; init; }
    }
}
