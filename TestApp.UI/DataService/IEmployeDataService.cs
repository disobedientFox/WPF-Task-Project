using System.Collections.Generic;
using System.Threading.Tasks;
using TestApp.Model;

namespace TestApp.UI.DataService
{
    public interface IEmployeDataService
    {
        Task<List<Employe>> GetAllAsync();
        Task SaveAsync(Employe employe);
    }
}