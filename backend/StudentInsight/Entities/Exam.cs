using StudentInsight.Entities.Common;
using StudentInsight.Enums;

namespace StudentInsight.Entities
{
    public sealed class Exam : CreatorBaseEntity
    {
        public ExamType Type { get; set; }
        public int TotalMarks { get; set; }
        public int TotalStudentsEnrolled { get; set; } = 0;
        public DateOnly DateOfConduct { get; set; }

        // Foreign Keys
        public Guid SubjectId { get; set; }
        
        // Navigation
        public Subject Subject { get; set; }
        public ICollection<StudentExamLogs> StudentExamLogs { get; set; }
    }
}
