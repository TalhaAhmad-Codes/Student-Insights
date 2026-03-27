using StudentInsight.DTOs.Common;

namespace StudentInsight.DTOs.SubjectDTOs
{
    public sealed class SubjectFilterDto : BaseCreatorFilterDto
    {
        public string? Name { get; init; }
    }
}
