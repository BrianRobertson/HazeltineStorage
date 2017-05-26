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
                ct => ct.Id,
                new CustomerType { Id = 1, TypeDescription = "--Select One--" },
                new CustomerType { Id = 2, TypeDescription = "Prospect"},
                new CustomerType { Id = 3, TypeDescription = "Active" },
                new CustomerType { Id = 4, TypeDescription = "Not Active" }
                );

            context.CustomerStatus.AddOrUpdate(
                cs => cs.Id,
                new CustomerStatus { Id = 1, StatusDescription = "--Select One--" },
                new CustomerStatus { Id = 2, StatusDescription = "Good" },
                new CustomerStatus { Id = 3, StatusDescription = "Past Due" },
                new CustomerStatus { Id = 4, StatusDescription = "Auction" },
                new CustomerStatus { Id = 5, StatusDescription = "D List" }
                );

            context.PaymentTypes.AddOrUpdate(
                pt => pt.Id,
                new PaymentType { Id = 1, PaymentTypeName = "--Select One--" },
                new PaymentType { Id = 2, PaymentTypeName = "Website" },
                new PaymentType { Id = 3, PaymentTypeName = "Mail" },
                new PaymentType { Id = 4, PaymentTypeName = "Drop Box" },
                new PaymentType { Id = 5, PaymentTypeName = "In Person" }
                );

        }
    }
}
