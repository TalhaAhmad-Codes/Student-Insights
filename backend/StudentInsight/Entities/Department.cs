using StudentInsight.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace StudentInsight.Entities
{
    public sealed class Department : CreatorBaseEntity
    {
        [Required]
        [MaxLength(75)]
        public string Name { get; set; }
        
        // Navigation
        public ICollection<Student> Students { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}
