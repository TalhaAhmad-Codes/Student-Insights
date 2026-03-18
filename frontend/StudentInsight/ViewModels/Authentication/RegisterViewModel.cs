using StudentInsight.Helpers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace StudentInsight.ViewModels.Authentication
{
    public class RegisterViewModel
    {
        private readonly AuthViewModel viewModel;

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICommand RegisterCommand { get; }
        public ICommand GoToLoginCommand { get; }

        public RegisterViewModel(AuthViewModel viewModel)
        {
            this.viewModel = viewModel;

            RegisterCommand = new RelayCommand(ExecuteRegister);
            GoToLoginCommand = new RelayCommand(_ => viewModel.ShowLogin());
        }

        private void ExecuteRegister(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            string password = passwordBox!.Password;

            // TODO: API call
            MessageBox.Show($"Register:\n{Username}\n{Email}\n{Password}");
        }

        private void GoToLogin(object obj)
        {
            viewModel.ShowLogin();
        }
    }
}
