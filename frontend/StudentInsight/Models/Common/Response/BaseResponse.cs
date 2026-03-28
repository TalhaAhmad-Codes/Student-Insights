namespace StudentInsight.Models.Common.Response
{
    public abstract class BaseResponse
    {
        public Guid Id { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}
