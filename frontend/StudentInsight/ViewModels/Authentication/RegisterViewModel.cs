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
    public class RegisterViewModel
    {
        private readonly AuthViewModel viewModel;
        public readonly ApiService apiService;

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICommand RegisterCommand { get; }
        public ICommand GoToLoginCommand { get; }

        public RegisterViewModel(AuthViewModel viewModel)
        {
            this.viewModel = viewModel;
            apiService = new();

            RegisterCommand = new RelayCommand(async (p) => await ExecuteRegister(p));
            GoToLoginCommand = new RelayCommand(_ => viewModel.ShowLogin());
        }

        private async Task ExecuteRegister(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            string password = passwordBox!.Password;

            RegisterRequest request = new()
            {
                Username = Username,
                Email = Email,
                Password = password
            };

            try
            {
                var response = await apiService.PostAsync<RegisterRequest, AuthenticationRespone>(UserRoute.Post.Register, request);

                SessionService.Instance.SetUser(response.UserId);

                MessageBox.Show("Registration successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GoToLogin(object obj)
        {
            viewModel.ShowLogin();
        }
    }
}
