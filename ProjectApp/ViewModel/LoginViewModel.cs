using ProjectApp.Core;
using ProjectApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApp.ViewModel
{
    public class LoginViewModel : Core.ViewModel
    {
        private INavigationService _navigation;

        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        private string _username;

        public string Username { 
            get => _username; 
            set 
            {
                _username = value;
                OnPropertyChanged();
            } 
        }

        private string _password;

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public LoginViewModel(INavigationService navigationService) {
            Navigation = navigationService;
        }

        public void Login() {
        
        }
    }
}
