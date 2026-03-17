using StudentInsight.DTOs.Common;

namespace StudentInsight.DTOs.StudentDTOs
{
    public sealed class StudentResponseDto : BaseCreatorDto
    {
        public string StudentName { get; init; }
        public string FatherName { get; init; }
        public int RollNumber { get; init; }
        public DateOnly DateOfBirth { get; init; }
        public Guid DepartmentId { get; init; }
    }
}
