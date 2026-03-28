namespace StudentInsight.Models.Users.Request
{
    public sealed class UserCreateRequest
    {
        public byte[]? ProfilePic { get; init; } = null;
        public string Username { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
    }
}
