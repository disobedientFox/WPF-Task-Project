using Prism.Commands;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using TestApp.Model;
using TestApp.UI.DataService;
using TestApp.UI.Tools;
using TestApp.UI.View;

namespace TestApp.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IEmployeDataService _employeDataService;
        private readonly IDataParser _dataParser;
        private Employe _selectedEmploye;

        public ICommand LoadFromCSVCommand { get; }
        public ICommand ShowEditFormCommand { get; }
        public ObservableCollection<Employe> Employes { get; } = new ObservableCollection<Employe>();


        public Employe SelectedEmploye
        {
            get => _selectedEmploye;
            
            set
            {
                _selectedEmploye = value;
                OnPropertryChanged();
            }
        }

        public MainViewModel(IEmployeDataService employeDataService, IDataParser dataParser)
        {
            _employeDataService = employeDataService ?? throw new System.ArgumentNullException(nameof(employeDataService));
            _dataParser = dataParser ?? throw new System.ArgumentNullException(nameof(dataParser));

            ShowEditFormCommand = new DelegateCommand(OnShowEditFormExecute, OnShowEditFormCanExecute);
            LoadFromCSVCommand = new DelegateCommand(OnLoadFromCSVExecute);
        }

        private void OnLoadFromCSVExecute()
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Select A File";
            openDialog.Filter = "CSV Files (*.csv*)|*.csv*";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                string file = openDialog.FileName;
                var records = _dataParser.Parse<Employe>(file);
                _employeDataService.InsertBatch(records);
            }
        }

        private bool OnShowEditFormCanExecute()
        {
            /*if (SelectedEmploye != null)
                return true;
            else
                return false;*/
            return true;
        }

        private void OnShowEditFormExecute()
        {
            EditViewModel editViewModel = new EditViewModel(_employeDataService);
            editViewModel.Load(SelectedEmploye);

            EditView editView = new EditView();
            editView.DataContext = editViewModel;
            editView.Show();
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
