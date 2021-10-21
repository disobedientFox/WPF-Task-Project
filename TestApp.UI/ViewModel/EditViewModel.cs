using Prism.Commands;
using System;
using System.Windows.Input;
using TestApp.Model;
using TestApp.UI.DataService;

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

        private async void OnSaveExecute()
        {
            await _dataService.SaveAsync(Employe);
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
