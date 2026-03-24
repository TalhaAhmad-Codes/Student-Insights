using StudentInsight.DTOs.Common;

namespace StudentInsight.DTOs.DepartmentDTOs
{
    public sealed class DepartmentResponseDto : BaseCreatorDto
    {
        public string Name { get; init; }
        public int TotalStudents { get; init; } = 0;
    }
}
