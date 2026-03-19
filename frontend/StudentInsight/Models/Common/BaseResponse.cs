namespace StudentInsight.Models.Common
{
    public abstract class BaseResponse
    {
        public Guid Id { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}
