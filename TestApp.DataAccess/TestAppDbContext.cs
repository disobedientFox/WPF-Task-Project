using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TestApp.Model;

namespace TestApp.DataAccess
{
    public class TestAppDbContext : DbContext
    {
        public DbSet<Employe> Employes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress; Initial Catalog=TestApp;Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employe>().ToTable("Employe");

            base.OnModelCreating(modelBuilder);
        }
    }
}
