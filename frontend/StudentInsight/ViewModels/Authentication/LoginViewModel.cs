using StudentInsight.Helpers;
using StudentInsight.Models.Authentication.Request;
using StudentInsight.Models.Authentication.Response;
using StudentInsight.Routes;
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
                var response = await apiService.PostAsync<LoginRequest, AuthenticationRespone>(UserRoute.Post.Login, request);

                SessionService.Instance.SetUser(response.UserId);   // Set the Guid for current session
                
                MessageBox.Show("Login successful!");

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
