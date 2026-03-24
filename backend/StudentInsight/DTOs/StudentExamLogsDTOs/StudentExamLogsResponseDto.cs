using StudentInsight.DTOs.Common;
using StudentInsight.Enums;

namespace StudentInsight.DTOs.StudentExamLogsDTOs
{
    public class StudentExamLogsResponseDto : BaseCreatorDto
    {
        public int ObtainedMarks { get; init; }
        public ExamStatus Status { get; init; }
        public string? Note { get; init; }
        public Guid StudentId { get; init; }
        public Guid ExamId { get; init; }
    }
}
