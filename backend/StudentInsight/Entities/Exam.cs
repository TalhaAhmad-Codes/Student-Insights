using StudentInsight.Entities.Common;
using StudentInsight.Enums;
using System.ComponentModel.DataAnnotations;

namespace StudentInsight.Entities
{
    public sealed class Exam : CreatorBaseEntity
    {
        [Required]
        public ExamType Type { get; set; }

        [Required]
        [Range(1, 100)]
        public int TotalMarks { get; set; }

        [Required]
        public DateOnly ConductedDate { get; set; }

        // Foreign Keys
        public Guid DepartmentId { get; set; }
        
        // Navigation
        public Department Department { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<StudentExamLogs> StudentExamLogs { get; set; }
    }
}
