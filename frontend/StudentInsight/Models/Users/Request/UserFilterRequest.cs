using StudentInsight.Models.Common.Request;

namespace StudentInsight.Models.Users.Request
{
    public sealed class UserFilterRequest : BaseFilterRequest
    {
        public string? Email { get; init; }
    }
}
