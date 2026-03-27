using StudentInsight.Entities.Common;

namespace StudentInsight.Entities
{
    public sealed class Subject : CreatorBaseEntity
    {
        public string Name { get; set; }

        public ICollection<Exam> Exams { get; set; }
    }
}
