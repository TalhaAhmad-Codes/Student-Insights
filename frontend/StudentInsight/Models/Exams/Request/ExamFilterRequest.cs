using StudentInsight.Enums;
using StudentInsight.Models.Common.Request;

namespace StudentInsight.Models.Exams.Request
{
    public sealed class ExamFilterRequest : BaseCreatorFilterRequest
    {
        public ExamType? Type { get; init; }
        public int? MinTotalMarks { get; init; }
        public int? MaxTotalMarks { get; init; }
        public DateOnly? FromConductedDate { get; init; }
        public DateOnly? ToConductedDate { get; init; }
        public Guid? SubjectId { get; init; }
    }
}
