using StudentInsight.DTOs.Common;
using StudentInsight.Enums;

namespace StudentInsight.DTOs.StudentExamLogsDTOs
{
    public sealed class StudentExamLogsUpdateDto : BaseDto
    {
        private string? note;

        public int ObtainedMarks { get; init; }
        public ExamStatus Status { get; init; }
        public string? Note
        {
            get => note;
            init => note = value?.Trim();
        }
        public Guid StudentId { get; init; }
        public Guid ExamId { get; init; }
    }
}
