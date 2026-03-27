using StudentInsight.Entities.Common;

namespace StudentInsight.Entities
{
    public sealed class User : BaseEntity
    {
        public byte[]? ProfilePic { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        // Navigation
        public ICollection<Student> Students { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public ICollection<StudentExamLogs> StudentExamLogs { get; set; }
    }
}
