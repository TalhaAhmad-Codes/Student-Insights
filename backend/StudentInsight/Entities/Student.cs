using StudentInsight.Entities.Common;

namespace StudentInsight.Entities
{
    public sealed class Student : CreatorBaseEntity
    {
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public int RollNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }

        // Foriegn Keys
        public Guid DepartmentId { get; set; }

        // Navigation
        public Department Department { get; set; }
        public ICollection<StudentExamLogs> StudentExamLogs { get; set; }
    }
}
