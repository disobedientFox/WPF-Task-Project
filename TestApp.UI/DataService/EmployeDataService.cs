using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestApp.DataAccess;
using TestApp.Model;

namespace TestApp.UI.DataService
{
    public class EmployeDataService : IEmployeDataService
    {
        //private Func<TestAppDbContext> _contextCreator;
        private TestAppDbContext _context;

        public EmployeDataService(TestAppDbContext context)
        {
            _context = context;
        }

        public async Task<Employe> GetByIdAsync(long id)
        {
            //using var ctx = _contextCreator();
            return await _context.Employes.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Employe>> GetAllAsync()
        {
            //using var ctx = _contextCreator();
            return await _context.Employes.AsNoTracking().ToListAsync().ConfigureAwait(false);
        }

        public async Task SaveAsync(Employe employe)
        {
            //using var ctx = _contextCreator();
            _context.Employes.Attach(employe);
            _context.Entry(employe).State = EntityState.Modified;
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task InsertBatch(IEnumerable<Employe> employes)
        {
            //using var ctx = _contextCreator();
            _context.Employes.AddRange(employes);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
