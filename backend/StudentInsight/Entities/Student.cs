using StudentInsight.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace StudentInsight.Entities
{
    public sealed class Student : CreatorBaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string StudentName { get; set; }

        [Required]
        [MaxLength(50)]
        public string FatherName { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int RollNumber { get; set; }

        [Required]
        public DateOnly DateOfBirth { get; set; }

        // Foriegn Keys
        public Guid DepartmentId { get; set; }

        // Navigation
        public Department Department { get; set; }
        public ICollection<StudentExamLogs> StudentExamLogs { get; set; }
    }
}
