using StudentInsight.DTOs.Common;

namespace StudentInsight.DTOs.StudentDTOs
{
    public sealed class StudentCreateDto : BaseCreatorCreateDto
    {
        private string studentName;

        public string StudentName
        {
            get => studentName;
            init => studentName = value.Trim();
        }
        public int RollNumber { get; init; }
    }
}
