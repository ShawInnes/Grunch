using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using Grunch.Core;

namespace Grunch.Data
{
    public interface IOrderDbContext : IDisposable
    {
        DbSet<MenuItem> MenuItems { get; set; }
        DbSet<MenuGrouping> MenuGroupings { get; set; }
        DbSet<Restaurant> Restaurants { get; set; }
        DbSet<Suburb> Suburbs { get; set; }
        DbSet<State> States { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<GroupOrder> GroupOrders { get; set; }

        bool HasChanges();
        int SaveChanges();
    }
}
