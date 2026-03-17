namespace StudentInsight.DTOs.UserDTOs
{
    public class UserLoginDto
    {
        private string email;

        public string Email
        {
            get => email;
            init => email = value.Trim().ToLower();
        }
        public string Password { get; init; }
    }
}
