namespace Grunch.Data
{
    using Grunch.Core;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OrderDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "WebSite.Models.OrderDbContext";
        }
        
        protected override void Seed(OrderDbContext context)
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

            context.Countries.AddOrUpdate(
                p => p.Code,
                new Country { Code = "au", Name = "Australia" },
                new Country { Code = "nz", Name = "New Zealand" },
                new Country { Code = "us", Name = "United States of America" } );
        }
    }
}
