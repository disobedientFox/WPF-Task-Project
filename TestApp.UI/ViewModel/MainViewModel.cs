using Microsoft.Win32;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using TestApp.Model;
using TestApp.UI.DataService;
using TestApp.UI.View;

namespace TestApp.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IEmployeDataService _employeDataService;

        public ICommand ShowEditFormCommand { get; }
        public ICommand LoadFromCSVCommand { get; }
        

        public MainViewModel(IEmployeDataService employeDataService)
        {
            _employeDataService = employeDataService ?? throw new System.ArgumentNullException(nameof(employeDataService));
            Employes = new ObservableCollection<Employe>();

            ShowEditFormCommand = new DelegateCommand(OnShowEditFormExecute, OnShowEditFormCanExecute);
            LoadFromCSVCommand = new DelegateCommand(OnLoadFromCSVExecute);
        }

        private void OnLoadFromCSVExecute()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files (*.csv*)|*.csv*";
            openFileDialog.ShowDialog();
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

        public ObservableCollection<Employe> Employes { get; }

        private Employe _selectedEmploye;

        public Employe SelectedEmploye
        {
            get { return _selectedEmploye; }
            set
            {
                _selectedEmploye = value;
                OnPropertryChanged();
            }
        }
    }
}
