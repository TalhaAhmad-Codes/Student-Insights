using StudentInsight.Models.Common.Request;

namespace StudentInsight.Models.Subjects.Request
{
    public sealed class SubjectUpdateRequest : BaseRequest
    {
        public string Name { get; init; }
    }
}
