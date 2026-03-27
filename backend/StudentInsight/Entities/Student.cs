using StudentInsight.Entities.Common;

namespace StudentInsight.Entities
{
    public sealed class Student : CreatorBaseEntity
    {
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public int RollNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }

        // Navigation
        public ICollection<StudentExamLogs> StudentExamLogs { get; set; }
    }
}
