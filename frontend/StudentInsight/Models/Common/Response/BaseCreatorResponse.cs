namespace StudentInsight.Models.Common.Response
{
    public abstract class BaseCreatorResponse : BaseResponse
    {
        public Guid CreatorId { get; init; }
    }
}
