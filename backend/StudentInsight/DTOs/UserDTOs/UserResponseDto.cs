using StudentInsight.DTOs.Common;

namespace StudentInsight.DTOs.UserDTOs
{
    public sealed class UserResponseDto : BaseAuditDto
    {
        public byte[]? ProfilePic { get; init; }
        public string Username { get; init; }
        public string Email { get; init; }
    }
}
