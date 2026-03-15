namespace StudentInsight.DTOs.Common
{
    public abstract class BaseCreatorFilterDto : BaseFilterDto
    {
        public Guid CreatorUserId { get; init; }
    }
}
