using StudentInsight.Models.Common;

namespace StudentInsight.Models.Users
{
    public sealed class UserResponse : BaseResponse
    {
        public string Username { get; init; }
        public string Email { get; init; }
    }
}
