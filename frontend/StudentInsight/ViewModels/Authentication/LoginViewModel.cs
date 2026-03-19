using StudentInsight.Helpers;
using StudentInsight.Models.Authentication;
using StudentInsight.Services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace StudentInsight.ViewModels.Authentication
{
    public class LoginViewModel
    {
        private readonly AuthViewModel viewModel;
        private readonly ApiService apiService;

        public string Email { get; set; }

        public ICommand LoginCommand { get; }
        public ICommand GoToRegisterCommand { get; }

        public LoginViewModel(AuthViewModel viewModel)
        {
            this.viewModel = viewModel;
            apiService = new ApiService();

            LoginCommand = new RelayCommand(async (p) => await ExecuteLogin(p));
            GoToRegisterCommand = new RelayCommand(_ => viewModel.ShowRegister());
        }

        private async Task ExecuteLogin(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            string password = passwordBox!.Password;

            LoginRequest request = new()
            {
                Email = Email,
                Password = password
            };

            try
            {
                var id = await apiService.PostAsync<LoginRequest, Guid>("User/login", request);

                SessionService.Instance.SetUser(id);   // Set the Guid for current session

                // On Success
                var mainWindow = new MainWindow();
                mainWindow.Show();

                // Close the current window
                Application.Current.Windows
                    .OfType<AuthWindow>()
                    .Single(w => w is AuthWindow)
                    .Close();
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

        private void GoToRegister(object obj)
        {
            viewModel.ShowRegister();
        }
    }
}
