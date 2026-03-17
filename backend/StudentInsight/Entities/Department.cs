using StudentInsight.Entities.Common;

namespace StudentInsight.Entities
{
    public sealed class Department : CreatorBaseEntity
    {
        public string Name { get; set; }
        
        // Navigation
        public ICollection<Student> Students { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}
