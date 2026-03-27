using StudentInsight.DTOs.Common;

namespace StudentInsight.DTOs.SubjectDTOs
{
    public sealed class SubjectCreateDto : BaseCreatorCreateDto
    {
        public string Name { get; init; }
    }
}
