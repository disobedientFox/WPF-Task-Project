using System.Threading.Tasks;
using TestApp.Model;

namespace TestApp.UI.ViewModel
{
    public interface IEditViewModel
    {
        Task Load(long id);
    }
}