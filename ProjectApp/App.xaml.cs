using Microsoft.Extensions.DependencyInjection;
using ProjectApp.Core;
using ProjectApp.Services;
using ProjectApp.View;
using ProjectApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton(provider => new MainView
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });
            services.AddSingleton<MainViewModel> ();
            services.AddSingleton<HomeViewModel> ();
            services.AddSingleton<RegexLibraryViewModel> ();
            services.AddSingleton<UsersViewModel> ();
            services.AddSingleton<INavigationService, NavigationService>();

            services.AddSingleton<Func<Type, Core.ViewModel>>(provider => viewModelType => (Core.ViewModel)provider.GetRequiredService(viewModelType));

            _serviceProvider = services.BuildServiceProvider ();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainView = _serviceProvider.GetRequiredService<MainView> ();
            mainView.Show();

            INavigationService nav = _serviceProvider.GetRequiredService<INavigationService>();
            RelayCommand navigateToHome = new RelayCommand(o => { nav.NavigateTo<HomeViewModel>(); }, o => true);
            

            base.OnStartup(e);
        }
    }
}
