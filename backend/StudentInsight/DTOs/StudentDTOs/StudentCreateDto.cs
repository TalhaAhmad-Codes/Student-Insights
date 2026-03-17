using StudentInsight.DTOs.Common;

namespace StudentInsight.DTOs.StudentDTOs
{
    public sealed class StudentCreateDto : BaseCreatorCreateDto
    {
        private string studentName;
        private string fatherName;

        public string StudentName
        {
            get => studentName;
            init => studentName = value.Trim();
        }
        public string FatherName
        {
            get => fatherName;
            init => fatherName = value.Trim();
        }
        public int RollNumber { get; init; }
        public DateOnly DateOfBirth { get; init; }
        public Guid DepartmentId { get; init; }
    }
}
