using StudentInsight.Enums;
using StudentInsight.Models.Common.Response;

namespace StudentInsight.Models.Exams.Response
{
    public sealed class ExamResponse : BaseCreatorResponse
    {
        public ExamType Type { get; init; }
        public int TotalMarks { get; init; }
        public int TotalStudentsEnrolled { get; init; }
        public DateOnly DateOfConduct { get; init; }
        public Guid SubjectId { get; init; }
    }
}
