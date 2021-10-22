using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using TestApp.Model;
using TestApp.UI.View;

namespace TestApp.UI.ViewModel
{
    public partial class MainViewModel
    {
        private async void OnLoadFromCSVExecute()
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Select A File";
            openDialog.Filter = "CSV Files (*.csv*)|*.csv*";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                string file = openDialog.FileName;
                var records = _dataParser.Parse<Employe>(file);
                await _employeDataService.InsertBatch(records);
            }

            await LoadAsync();
        }

        private bool OnOpenEditViewCanExecute()
        {
            return SelectedEmploye != null && !IsEditViewOpen;
        }

        private async Task OnOpenEditViewExecuteAsync()
        {
            EditViewModel editViewModel = new EditViewModel(_employeDataService, _eventAggregator);
            await editViewModel.Load(SelectedEmploye.Id);

            EditView editView = new EditView();
            editView.DataContext = editViewModel;
            editView.Show();
            IsEditViewOpen = true;
        }
    }
}
