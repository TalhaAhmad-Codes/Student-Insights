using StudentInsight.DTOs.Common;

namespace StudentInsight.DTOs.UserDTOs
{
    public sealed class UserFilterDto : BaseFilterDto
    {
        private string? email;

        public string? Email
        {
            get => email;
            init => email = value?.Trim().ToLower();
        }
    }
}
