using StudentInsight.DTOs.Common;
using StudentInsight.Enums;

namespace StudentInsight.DTOs.StudentExamLogsDTOs
{
    public sealed class StudentExamLogsFilterDto : BaseCreatorFilterDto
    {
        public int? MinObtainedMarks { get; init; }
        public int? MaxObtainedMarks { get; init; }
        public ExamStatus? Status { get; init; }
        public Guid? StudentId { get; init; }
        public Guid? ExamId { get; init; }
    }
}
