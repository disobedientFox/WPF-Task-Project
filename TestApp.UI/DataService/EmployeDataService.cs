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
            _contextCreator = contextCreator ?? throw new ArgumentNullException(nameof(contextCreator));
        }

        public async Task<Employe> GetByIdAsync(long id)
        {
            using var ctx = _contextCreator();
            return await ctx.Employes.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Employe>> GetAllAsync()
        {
            using var ctx = _contextCreator();
            return await ctx.Employes.AsNoTracking().ToListAsync().ConfigureAwait(false);
        }

        public async Task SaveAsync(Employe employe)
        {
            using var ctx = _contextCreator();
            ctx.Employes.Attach(employe);
            ctx.Entry(employe).State = EntityState.Modified;
            await ctx.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task InsertBatch(IEnumerable<Employe> employes)
        {
            using var ctx = _contextCreator();
            ctx.Employes.AddRange(employes);
            await ctx.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
