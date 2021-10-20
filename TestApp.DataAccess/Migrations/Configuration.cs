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

        }
    }
}
