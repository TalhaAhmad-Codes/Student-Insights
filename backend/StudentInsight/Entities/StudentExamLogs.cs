using StudentInsight.Entities.Common;
using StudentInsight.Enums;
using System.ComponentModel.DataAnnotations;

namespace StudentInsight.Entities
{
    public sealed class StudentExamLogs : CreatorBaseEntity
    {
        [Required]
        [Range(0, 100)]
        public int ObtainedMarks { get; set; }

        [Required]
        public ExamStatus Status { get; set; }

        [MaxLength(150)]
        public string? Note { get; set; }

        // Foreign Keys
        public Guid StudentId { get; set; }
        public Guid ExamId { get; set; }

        // Navigation
        public Student Student { get; set; }
        public Exam Exam { get; set; }
    }
}
