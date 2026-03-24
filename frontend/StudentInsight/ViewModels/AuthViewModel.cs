using StudentInsight.ViewModels.Authentication;
using System.ComponentModel;

namespace StudentInsight.ViewModels
{
    public class AuthViewModel : INotifyPropertyChanged
    {
        private object currentView;

        public object CurrentView
        {
            get => currentView;
            set
            {
                currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public AuthViewModel()
        {
            // Default view
            CurrentView = new LoginViewModel(this);
        }

        public void ShowLogin()
        {
            CurrentView = new LoginViewModel(this);
        }

        public void ShowRegister()
        {
            CurrentView = new RegisterViewModel(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}