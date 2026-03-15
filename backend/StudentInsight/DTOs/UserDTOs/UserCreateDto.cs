namespace StudentInsight.DTOs.UserDTOs
{
    public sealed class UserCreateDto
    {
        public byte[]? ProfilePic { get; init; }
        public string Username { get; init; }
        public string Email { get; init; }
    }
}
