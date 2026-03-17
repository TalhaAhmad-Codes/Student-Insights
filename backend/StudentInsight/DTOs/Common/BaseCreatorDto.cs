namespace StudentInsight.DTOs.Common
{
    public abstract class BaseCreatorDto : BaseAuditDto
    {
        public Guid CreatorUserId { get; init; }
    }
}
