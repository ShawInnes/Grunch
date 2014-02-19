using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Grunch.Core;

namespace Grunch.Data
{
    public class OrderDbContext
            : DbContext, 
            IOrderDbContext
    {
        public OrderDbContext()
            : base("DefaultConnection")
        {
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
    }
}
