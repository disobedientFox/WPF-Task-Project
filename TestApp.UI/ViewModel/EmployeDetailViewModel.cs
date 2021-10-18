using Prism.Events;
using System;
using System.Threading.Tasks;
using TestApp.Model;
using TestApp.UI.DataService;
using TestApp.UI.Event;

namespace TestApp.UI.ViewModel
{
    class EmployeDetailViewModel : ViewModelBase, IEmployeDetailViewModel
    {
        private IEmployeDataService _dataService;
        private IEventAggregator _eventAggregator;

        public EmployeDetailViewModel(IEmployeDataService dataService,
            IEventAggregator eventAggregator)
        {
            _dataService = dataService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenEmployeDetailViewEvent>()
                        .Subscribe(OnOpenEmployeDetailView);
        }
        private async void OnOpenEmployeDetailView(long employeId)
        {
            await LoadAsync(employeId);
        }

        public async Task LoadAsync(long employeId)
        {
            Employe = await _dataService.GetByIdAsync(employeId);
        }
        private Employe _employe;

        public Employe Employe
        {
            get { return _employe; }
            private set
            {
                _employe = value;
                OnPropertryChanged();
            }
        }
    }
}
