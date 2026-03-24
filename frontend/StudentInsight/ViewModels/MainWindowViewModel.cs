using StudentInsight.Models.Users;
using StudentInsight.Routes;
using StudentInsight.Services;
using System.ComponentModel;
using System.Windows;

namespace StudentInsight.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly ApiService apiService;
        private readonly Guid userId;
        private string username;
        
        public UserResponse UserResponse { get; private set; }

        public string UserId { get; }
        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public MainWindowViewModel()
        {
            apiService = new ApiService();

            // Get UserId from session
            userId = SessionService.Instance.UserId;
            UserId = userId.ToString();

            _ = LoadUser();
        }

        private async Task LoadUser()
        {
            try
            {
                UserResponse = await apiService.GetAsync<UserResponse>(UserRoute.Get.ById(userId));
                Username = UserResponse.Username;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
