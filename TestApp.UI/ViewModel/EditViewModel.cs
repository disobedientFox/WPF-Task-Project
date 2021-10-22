using GalaSoft.MvvmLight.Command;
using Prism.Events;
using System;
using System.Threading.Tasks;
using System.Windows;
using TestApp.UI.DataService;
using TestApp.UI.Event;
using TestApp.UI.Interface;
using TestApp.UI.Wrapper;

namespace TestApp.UI.ViewModel
{
    class EditViewModel : ViewModelBase, IEditViewModel
    {
        private readonly IEmployeDataService _dataService;
        private readonly IEventAggregator _eventAggregator;
        private EmployeWrapper _employe;

        public EmployeWrapper Employe
        {
            get { return _employe; }
            private set
            {
                _employe = value;
            }
        }
        public RelayCommand<IClosable> SaveCommand { get; }
        public RelayCommand<IClosable> CloseCommand { get; }

        public EditViewModel(IEmployeDataService dataService, IEventAggregator eventAggregator)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _eventAggregator = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));

            SaveCommand = new RelayCommand<IClosable>(OnSaveExecute);
            CloseCommand = new RelayCommand<IClosable>(OnCloseExecute);
        }

        public async Task Load(long id)
        {
            var employe = await _dataService.GetByIdAsync(id);
            Employe = new EmployeWrapper(employe);
        }
        private async void OnSaveExecute(IClosable window)
        {
            await _dataService.SaveAsync(Employe.Model);
            _eventAggregator.GetEvent<EditCompleteEvent>().Publish(true);
            MessageBox.Show("Employe has been updated");
            CloseWindow(window);
        }

        private void OnCloseExecute(IClosable window)
        {
            _eventAggregator.GetEvent<EditCompleteEvent>().Publish(true);
            CloseWindow(window);
        }

        private void CloseWindow(IClosable window)
        {
            if (window != null)
            {
                window.Close();
            }
        }
    }
}
