namespace StudentInsight.Services
{
    public class SessionService
    {
        private static readonly SessionService _instance = new();

        public static SessionService Instance => _instance;

        public Guid UserId { get; private set; }

        private SessionService() { }

        public void SetUser(Guid userId)
        {
            UserId = userId;
        }

        public void Clear()
        {
            UserId = Guid.Empty;
        }

        public bool IsLoggedIn => UserId != Guid.Empty;
    }
}
