namespace StudentInsight.Models.Common.Request
{
    public abstract class BaseFilterRequest
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }

    public abstract class BaseCreatorFilterRequest : BaseFilterRequest
    {
        public Guid? CreatorUserId { get; init; }
    }
}
