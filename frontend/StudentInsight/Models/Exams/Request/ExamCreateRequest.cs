using StudentInsight.Enums;
using StudentInsight.Models.Common.Request;

namespace StudentInsight.Models.Exams.Request
{
    public sealed class ExamCreateRequest : BaseCreatorRequest
    {
        public ExamType Type { get; init; }
        public int TotalMarks { get; init; }
        public DateOnly DateOfConduct { get; init; }
        public Guid SubjectId { get; init; }

    }
}
