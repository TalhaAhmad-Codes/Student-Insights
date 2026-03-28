using StudentInsight.Models.Common.Request;

namespace StudentInsight.Models.Subjects.Request
{
    public sealed class SubjectCreateRequest : BaseCreatorRequest
    {
        public string Name { get; init; }
    }
}
