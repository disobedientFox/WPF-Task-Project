using Prism.Events;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TestApp.Model;
using TestApp.UI.DataService;
using TestApp.UI.Event;

namespace TestApp.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private IEmployeLookupDataService _employeLookupDataService;
        private IEventAggregator _eventAggregator;

        public NavigationViewModel(IEmployeLookupDataService employeLookupDataService,
            IEventAggregator eventAggregator)
        {
            _employeLookupDataService = employeLookupDataService;
            Employes = new ObservableCollection<LookupItem>();
            _eventAggregator = eventAggregator;
        }

        public async Task LoadAsync()
        {
            var lookup = await _employeLookupDataService.GetEmployeLookupAsync();
            Employes.Clear();
            foreach (var item in lookup)
            {
                Employes.Add(item);
            }
        }

        public ObservableCollection<LookupItem> Employes { get; }

        private LookupItem _selectedEmploye;

        public LookupItem SelectedEmploye
        {
            get { return _selectedEmploye; }
            set
            {
                _selectedEmploye = value;
                OnPropertryChanged();
                if(_selectedEmploye!=null)
                {
                    _eventAggregator.GetEvent<OpenEmployeDetailViewEvent>()
                        .Publish(_selectedEmploye.Id);
                }
            }
        }
    }
}
