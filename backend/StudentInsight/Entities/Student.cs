using StudentInsight.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace StudentInsight.Entities
{
    public sealed class Student : CreatorBaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string RollNumber { get; set; }

        [Required]
        public DateOnly DateOfBirth { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }

        // Foriegn Keys
        public Guid DepartmentId { get; set; }

        // Navigation
        public Department Department { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public ICollection<StudentExamLogs> StudentExamLogs { get; set; }
    }
}
