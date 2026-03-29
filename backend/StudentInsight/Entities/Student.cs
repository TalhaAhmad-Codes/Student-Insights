using StudentInsight.Entities.Common;

namespace StudentInsight.Entities
{
    public sealed class Student : CreatorBaseEntity
    {
        public string StudentName { get; set; }
        public int RollNumber { get; set; }

        // Navigation
        public ICollection<StudentExamLogs> StudentExamLogs { get; set; }
    }
}
