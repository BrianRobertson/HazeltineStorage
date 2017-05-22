namespace HazeltineStorage.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HazeltineStorage.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HazeltineStorage.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.CustomerTypes.AddOrUpdate(
                x => x.Id,
                new CustomerType { Id = 1, TypeDescription = "" },
                new CustomerType { Id = 2, TypeDescription = "Prospect"},
                new CustomerType { Id = 3, TypeDescription = "Active" },
                new CustomerType { Id = 4, TypeDescription = "Not Active" }
                );


        }
    }
}
