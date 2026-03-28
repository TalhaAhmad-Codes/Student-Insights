using StudentInsight.Models.Common.Request;

namespace StudentInsight.Models.Users.Request.UserUpdateRequests
{
    public sealed class UserUpdateProfilePicRequest : BaseRequest
    {
        public byte[]? ProfilePic { get; init; }
    }

    public sealed class UserUpdateUsernameRequest : BaseRequest
    {
        public string Username { get; init; }
    }

    public sealed class UserUpdatePasswordRequest : BaseRequest
    {
        public string OldPassword { get; init; }
        public string NewPassword { get; init; }
        public string ConfirmPassword { get; init; }
    }
}
