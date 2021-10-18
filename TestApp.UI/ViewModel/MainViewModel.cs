using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TestApp.Model;
using TestApp.UI.DataService;

namespace TestApp.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public INavigationViewModel NavigationViewModel { get; }
        public IEmployeDetailViewModel EmployeDetailViewModel { get; }

        public MainViewModel(INavigationViewModel navigationViewModel,
            IEmployeDetailViewModel employeDetailViewModel)
        {
            NavigationViewModel = navigationViewModel;
            EmployeDetailViewModel = employeDetailViewModel;
        }

        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();
        }

    }
}
