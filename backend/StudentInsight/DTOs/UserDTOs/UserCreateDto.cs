namespace StudentInsight.DTOs.UserDTOs
{
    public sealed class UserCreateDto
    {
        private string username;
        private string email;
        
        public byte[]? ProfilePic { get; init; } = null;
        public string Username
        {
            get => username;
            init => username = value.Trim();
        }
        public string Email
        {
            get => email;
            init => email = value.Trim();
        }
        public string Password { get; init; }
    }
}
