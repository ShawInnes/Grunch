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
            AutomaticMigrationsEnabled = false;
            ContextKey = "WebSite.Models.OrderDbContext";
        }
        
        protected override void Seed(OrderDbContext context)
        {
            context.Countries.AddOrUpdate(
                p => p.Code,
                new Country { Code = "au", Name = "Australia" },
                new Country { Code = "nz", Name = "New Zealand" },
                new Country { Code = "us", Name = "United States of America" } );

            context.Restaurants.AddOrUpdate(
                p => p.Name,
                new Restaurant { Name = "Brew Bakers" }, 
                new Restaurant { Name = "Sanga Sushi" }, 
                new Restaurant { Name = "Sitar Indian" }, 
                new Restaurant { Name = "Efes One Turkish" } );
        }
    }
}
