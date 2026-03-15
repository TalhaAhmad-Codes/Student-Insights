using StudentInsight.DTOs.Common;

namespace StudentInsight.DTOs.StudentDTOs
{
    public sealed class StudentFilterDto : BaseCreatorFilterDto
    {
        public string? StudentName { get; init; }
        public string? FatherName { get; init; }
        public int? RollNumber { get; init; }
        public DateOnly? DateOfBirth { get; init; }
        public Guid? DepartmentId { get; init; }
    }
}
