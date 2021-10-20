using Prism.Commands;
using Prism.Events;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using TestApp.Model;
using TestApp.UI.DataService;
using TestApp.UI.Event;

namespace TestApp.UI.ViewModel
{
    class EditViewModel : ViewModelBase, IEditViewModel
    {
        private IEmployeDataService _dataService;

        public EditViewModel(IEmployeDataService dataService)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        private bool OnSaveCanExecute()
        {
            return true;
        }

        private void OnSaveExecute()
        {
            throw new NotImplementedException();
        }

        public void Load(Employe employe)
        {
            Employe = employe;
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

        public ICommand SaveCommand { get; }
    }
}
