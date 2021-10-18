using System.Threading.Tasks;

namespace TestApp.UI.ViewModel
{
    public interface IEmployeDetailViewModel
    {
        Task LoadAsync(long employeId);
    }
}