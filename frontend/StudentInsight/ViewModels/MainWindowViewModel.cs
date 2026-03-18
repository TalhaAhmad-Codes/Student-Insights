using StudentInsight.Services;

namespace StudentInsight.ViewModels
{
    public class MainWindowViewModel
    {
        public string UserId { get; }

        public MainWindowViewModel()
        {
            // Get UserId from session
            UserId = SessionService.Instance.UserId.ToString();
        }
    }
}
