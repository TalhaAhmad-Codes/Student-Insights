using StudentInsight.Entities.Common;
using StudentInsight.Enums;

namespace StudentInsight.Entities
{
    public sealed class Exam : CreatorBaseEntity
    {
        public ExamType Type { get; set; }
        public int TotalMarks { get; set; }
        public DateOnly ConductedDate { get; set; }

        // Foreign Keys
        public Guid DepartmentId { get; set; }
        
        // Navigation
        public Department Department { get; set; }
        public ICollection<StudentExamLogs> StudentExamLogs { get; set; }
    }
}
