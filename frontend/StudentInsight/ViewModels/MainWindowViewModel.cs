using StudentInsight.Models.Users;
using StudentInsight.Services;
using System.ComponentModel;
using System.Windows;

namespace StudentInsight.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly ApiService apiService;
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
            UserId = SessionService.Instance.UserId.ToString();

            _ = LoadUser();
        }

        private async Task LoadUser()
        {
            try
            {
                UserResponse = await apiService.GetAsync<UserResponse>($"User/{UserId}");
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
