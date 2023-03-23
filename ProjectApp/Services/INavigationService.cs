using ProjectApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApp.Services
{
    public interface INavigationService
    {

        Core.ViewModel CurrentView { get; }

        void NavigateTo<T>() where T : Core.ViewModel;

    }
}
