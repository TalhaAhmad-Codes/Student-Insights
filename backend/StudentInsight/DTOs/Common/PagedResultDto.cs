namespace StudentInsight.DTOs.Common
{
    public sealed class PagedResultDto<T> where T : class
    {
        public List<T> Items { get; init; }
        public int TotalCount { get; init; }
    }
}
