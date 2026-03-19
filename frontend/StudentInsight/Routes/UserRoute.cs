namespace StudentInsight.Routes
{
    public static class UserRoute
    {
        public static string Endpoint => "User";

        public static class Get
        {
            public static string All => $"{Endpoint}";
            public static string ById(Guid id) => $"{Endpoint}/{id}";
        }

        public static class Post
        {
            public static string Create => $"{Endpoint}";
            public static string CreateBulk => $"{Endpoint}/bulk";
            public static string Login => $"{Endpoint}/login";
            public static string Register => $"{Endpoint}/register";
        }

        public static class Delete
        {
            public static string ById(Guid id) => $"{Endpoint}/{id}";
        }

        public static class Patch
        {
            public static string ProfilePic => $"{Endpoint}/update/profile-pic";
            public static string Username => $"{Endpoint}/update/username";
            public static string Password => $"{Endpoint}/update/password";
        }
    }
}
