using ProjectApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApp.ViewModel
{
    public class HomeViewModel : Core.ViewModel
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

        private string _title;
        public string Title { 
            get => _title; 
            set { 
                _title = value;
                OnPropertyChanged();
            } 
        }

        public HomeViewModel(INavigationService navigation) {
            Navigation = navigation;
            Title = "Test here";
        }

    }
}
