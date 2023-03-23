using ProjectApp.Core;
using ProjectApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApp.ViewModel
{
    public class MainViewModel : Core.ViewModel
    {

        private INavigationService _navigation;

        public INavigationService Navigation
        {
            get => _navigation;
            set {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NavigateToHomeCommand { get; set; }

        public MainViewModel(INavigationService navigationService) {
            Navigation = navigationService;
            NavigateToHomeCommand = new RelayCommand(o => { Navigation.NavigateTo<HomeViewModel>(); }, o => true);
        }
    }
}
