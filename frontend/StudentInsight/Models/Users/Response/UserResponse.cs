using StudentInsight.Models.Common.Response;

namespace StudentInsight.Models.Users.Response
{
    public sealed class UserResponse : BaseResponse
    {
        public string Username { get; init; }
        public string Email { get; init; }
    }
}
