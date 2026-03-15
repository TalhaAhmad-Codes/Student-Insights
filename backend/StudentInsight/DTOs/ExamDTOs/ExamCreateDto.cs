using StudentInsight.DTOs.Common;
using StudentInsight.Enums;

namespace StudentInsight.DTOs.ExamDTOs
{
    public sealed class ExamCreateDto : BaseCreatorCreateDto
    {
        public ExamType Type { get; init; }
        public int TotalMarks { get; init; }
        public DateOnly ConductedDate { get; init; }
        public Guid DepartmentId { get; init; }
    }
}
