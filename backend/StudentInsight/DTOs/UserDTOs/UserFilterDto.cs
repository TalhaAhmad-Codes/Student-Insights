using StudentInsight.DTOs.Common;

namespace StudentInsight.DTOs.UserDTOs
{
    public sealed class UserFilterDto : BaseFilterDto
    {
        public string? Email { get; init; }
    }
}
