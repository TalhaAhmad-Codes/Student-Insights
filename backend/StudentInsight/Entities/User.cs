using StudentInsight.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace StudentInsight.Entities
{
    public sealed class User : BaseEntity
    {
        public byte[]? ProfilePic { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(150)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        // Navigation
        public ICollection<Student> Students { get; set; }
        public ICollection<Department> Departments { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public ICollection<StudentExamLogs> StudentExamLogs { get; set; }
    }
}
