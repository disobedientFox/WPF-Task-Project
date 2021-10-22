using GalaSoft.MvvmLight.Command;
using Prism.Commands;
using Prism.Events;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TestApp.Model;
using TestApp.UI.DataService;
using TestApp.UI.Event;
using TestApp.UI.Tools;

namespace TestApp.UI.ViewModel
{
    public partial class MainViewModel : ViewModelBase
    {
        private readonly IEmployeDataService _employeDataService;
        private readonly IDataParser _dataParser;
        private readonly IEventAggregator _eventAggregator;
        private Employe _selectedEmploye;

        public Employe SelectedEmploye
        {
            get => _selectedEmploye;
            
            set
            {
                _selectedEmploye = value;
                OnPropertryChanged();
            }
        }
        public ICommand LoadFromCSVCommand { get; }
        public ICommand OpenEditViewCommand { get; }
        public ObservableCollection<Employe> Employes { get; } = new ObservableCollection<Employe>();


        public MainViewModel(IEmployeDataService employeDataService, IDataParser dataParser, IEventAggregator eventAggregator)
        {
            _employeDataService = employeDataService ?? throw new System.ArgumentNullException(nameof(employeDataService));
            _dataParser = dataParser ?? throw new System.ArgumentNullException(nameof(dataParser));
            _eventAggregator = eventAggregator ?? throw new System.ArgumentNullException(nameof(eventAggregator));

            OpenEditViewCommand = new DelegateCommand(async() => await OnOpenEditViewExecuteAsync(), OnOpenEditViewCanExecute).ObservesProperty(() => SelectedEmploye);
            LoadFromCSVCommand = new DelegateCommand(OnLoadFromCSVExecute);

            //_eventAggregator.GetEvent<EditCompleteEvent>()
            //    .Subscribe(LoadAsync);
        }

        public async Task LoadAsync()
        {
            var employes = await _employeDataService.GetAllAsync();
            Employes.Clear();
            foreach (var item in employes)
            {
                Employes.Add(item);
            }
        }
    }
}
