using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Grunch.Core;
using System.Data.Entity.ModelConfiguration.Conventions;
using Grunch.Data.Migrations;

namespace Grunch.Data
{
    public class OrderDbContext
            : DbContext, 
            IOrderDbContext
    {
        public OrderDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OrderDbContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public bool HasChanges()
        {
            return base.ChangeTracker.HasChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
        
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public DbSet<GroupOrder> GroupOrders { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Suburb> Suburbs { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<MenuGrouping> MenuGroupings { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
    }
}
