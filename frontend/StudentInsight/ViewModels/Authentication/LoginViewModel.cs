using StudentInsight.Helpers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace StudentInsight.ViewModels.Authentication
{
    public class LoginViewModel
    {
        private readonly AuthViewModel viewModel;

        public string Email { get; set; }

        public ICommand LoginCommand { get; }
        public ICommand GoToRegisterCommand { get; }

        public LoginViewModel(AuthViewModel viewModel)
        {
            this.viewModel = viewModel;

            LoginCommand = new RelayCommand(ExecuteLogin);
            GoToRegisterCommand = new RelayCommand(_ => viewModel.ShowRegister());
        }

        private void ExecuteLogin(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            string password = passwordBox!.Password;

            // TODO: Call API (Auth Service)

            bool isSuccess = true;

            if (isSuccess)
            {
                // Open the main window
                var mainWindow = new MainWindow();
                mainWindow.Show();

                // Close the auth window
                Application.Current.Windows
                    .OfType<Window>()
                    .Single(w => w is AuthWindow)
                    .Close();
            }
        }

        private void GoToRegister(object obj)
        {
            viewModel.ShowRegister();
        }
    }
}
