using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TestApp.DataAccess;
using TestApp.Model;

namespace TestApp.UI.DataService
{
    public class EmployeDataService : IEmployeDataService
    {
        private Func<TestAppDbContext> _contextCreator;

        public EmployeDataService(Func<TestAppDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<Employe> GetByIdAsync(long employeId)
        {
            using var ctx = _contextCreator();
            return await ctx.Employes.AsNoTracking().SingleOrDefaultAsync(x => x.Id == employeId);
        }
    }
}
