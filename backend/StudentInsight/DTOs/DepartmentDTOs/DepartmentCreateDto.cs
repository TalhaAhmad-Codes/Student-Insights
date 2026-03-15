using StudentInsight.DTOs.Common;

namespace StudentInsight.DTOs.DepartmentDTOs
{
    public sealed class DepartmentCreateDto : BaseCreatorCreateDto
    {
        public string Name { get; init; }
    }
}
