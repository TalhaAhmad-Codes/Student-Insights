using StudentInsight.Entities.Common;
using StudentInsight.Enums;

namespace StudentInsight.Entities
{
    public sealed class StudentExamLogs : CreatorBaseEntity
    {
        public int ObtainedMarks { get; set; }
        public ExamStatus Status { get; set; }
        public string? Note { get; set; }

        // Foreign Keys
        public Guid StudentId { get; set; }
        public Guid ExamId { get; set; }

        // Navigation
        public Student Student { get; set; }
        public Exam Exam { get; set; }
    }
}
