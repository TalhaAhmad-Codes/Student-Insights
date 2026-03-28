using StudentInsight.Models.Common.Request;

namespace StudentInsight.Models.Subjects.Request
{
    public sealed class SubjectFilterRequest : BaseCreatorFilterRequest
    {
        public string? Name { get; init; }
    }
}
