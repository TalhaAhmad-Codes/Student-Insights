using StudentInsight.DTOs.Common;
using System.Runtime.CompilerServices;

namespace StudentInsight.DTOs.UserDTOs.UserUpdateDtos
{
    public sealed class UserUpdateProfilePicDto : BaseDto
    {
        public byte[]? ProfilePic { get; init; }
    }

    public sealed class UserUpdateUsernameDto : BaseDto
    {
        private string username;

        public string Username
        {
            get => username;
            init => username = value.Trim();
        }
    }

    public sealed class UserChangePasswordDto : BaseDto
    {
        public string OldPassword { get; init; }
        public string NewPassword { get; init; }
        public string ConfirmPassword { get; init; }
    }
}
