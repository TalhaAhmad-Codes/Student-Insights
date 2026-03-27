using StudentInsight.DTOs.Common;
using StudentInsight.Enums;

namespace StudentInsight.DTOs.ExamDTOs
{
    public sealed class ExamFilterDto : BaseCreatorFilterDto
    {
        public ExamType? Type { get; init; }
        public int? MinTotalMarks { get; init; }
        public int? MaxTotalMarks { get; init; }
        public DateOnly? FromConductedDate { get; init; }
        public DateOnly? ToConductedDate { get; init; }
        public Guid? SubjectId { get; init; }
    }
}
