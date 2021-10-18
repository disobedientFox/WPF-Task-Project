using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using TestApp.Model;

namespace TestApp.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TestApp.DataAccess.TestAppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TestApp.DataAccess.TestAppDbContext context)
        {
            context.Employes.AddOrUpdate(
                x => x.FirstName,
                new Employe { FirstName = "Ania", LastName = "Soja", Email = "asoja@example.com", Number = "123321456" },
                new Employe { FirstName = "Antonio", LastName = "Mars", Email = "amars@example.com", Number = "265873256" },
                new Employe { FirstName = "Mira", LastName = "Aoro", Email = "maoro@example.com", Number = "123452698" },
                new Employe { FirstName = "Nord", LastName = "Sano", Email = "nsano@example.com", Number = "567124965" }
                );
        }
    }
}
