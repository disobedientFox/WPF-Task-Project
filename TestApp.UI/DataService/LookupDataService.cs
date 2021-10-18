using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TestApp.DataAccess;
using TestApp.Model;

namespace TestApp.UI.DataService
{
    public class LookupDataService : IEmployeLookupDataService
    {
        private Func<TestAppDbContext> _contexCreator;

        public LookupDataService(Func<TestAppDbContext> contextCreator)
        {
            _contexCreator = contextCreator;
        }

        public async Task<IEnumerable<LookupItem>> GetEmployeLookupAsync()
        {
            using (var ctx = _contexCreator())
            {
                return await ctx.Employes.AsNoTracking()
                    .Select(x =>
                    new LookupItem
                    {
                        Id = x.Id,
                        DisplayMember = x.FirstName + " " + x.LastName
                    }).ToListAsync();
            }
        }
    }
}
