using ProjectApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApp.Services
{
    public class NavigationService : ObservableObject, INavigationService
    {
        private readonly Func<Type, Core.ViewModel> _viewModelFactory;
        private Core.ViewModel _currentView;

        public Core.ViewModel CurrentView { 
            get => _currentView;
            private set {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public NavigationService(Func<Type, Core.ViewModel> viewModelFactory) { 
            _viewModelFactory = viewModelFactory;
        }

        public void NavigateTo<TViewModel>() where TViewModel : Core.ViewModel
        {
            Core.ViewModel viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
            CurrentView = viewModel;
        }

    }
}
