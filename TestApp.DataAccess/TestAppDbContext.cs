using TestApp.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TestApp.DataAccess
{
    public class TestAppDbContext : DbContext
    {
        public TestAppDbContext() : base("TestAppDb")
        {

        }

        public DbSet<Employe> Employes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
