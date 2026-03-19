namespace StudentInsight.Routes
{
    public static class StudentExamLogsRoute
    {
        public static string Endpoint => "StudentExamLogs";

        public static class Get
        {
            public static string All => $"{Endpoint}";
            public static string ById(Guid id) => $"{Endpoint}/{id}";
        }

        public static class Post
        {
            public static string Create => $"{Endpoint}";
            public static string CreateBulk => $"{Endpoint}/bulk";
        }

        public static class Put
        {
            public static string Update => $"{Endpoint}";
        }

        public static class Delete
        {
            public static string ById(Guid id) => $"{Endpoint}/{id}";
        }
    }
}
