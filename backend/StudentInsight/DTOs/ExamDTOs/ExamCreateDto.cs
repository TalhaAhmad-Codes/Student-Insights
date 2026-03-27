using StudentInsight.DTOs.Common;
using StudentInsight.Enums;

namespace StudentInsight.DTOs.ExamDTOs
{
    public sealed class ExamCreateDto : BaseCreatorCreateDto
    {
        public ExamType Type { get; init; }
        public int TotalMarks { get; init; }
        public DateOnly DateOfConduct { get; init; }
        public Guid SubjectId { get; init; }
    }
}
