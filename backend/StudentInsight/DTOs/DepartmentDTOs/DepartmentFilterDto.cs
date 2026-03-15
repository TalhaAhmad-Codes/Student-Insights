using StudentInsight.DTOs.Common;

namespace StudentInsight.DTOs.DepartmentDTOs
{
    public sealed class DepartmentFilterDto : BaseCreatorFilterDto
    {
        public string? Name { get; init; }
    }
}
