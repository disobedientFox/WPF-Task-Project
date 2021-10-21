using System.Collections.Generic;
using System.Threading.Tasks;
using TestApp.Model;

namespace TestApp.UI.DataService
{
    public interface IEmployeDataService
    {
        Task<IEnumerable<Employe>> GetAllAsync();
        Task InsertBatch(IEnumerable<Employe> employes);
        Task SaveAsync(Employe employe);
    }
}