using StudentInsight.DTOs.Common;

namespace StudentInsight.DTOs.UserDTOs.UserUpdateDtos
{
    public sealed class UserUpdateProfilePicDto : BaseDto
    {
        public byte[]? ProfilePic { get; init; }
    }

    public sealed class UserUpdateUsernameDto : BaseDto
    {
        public string Username { get; init; }
    }

    public sealed class UserChangePasswordDto : BaseDto
    {
        public string OldPassword { get; init; }
        public string NewPassword { get; init; }
        public string ConfirmPassword { get; init; }
    }
}
