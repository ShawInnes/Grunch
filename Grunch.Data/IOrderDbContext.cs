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
        DbSet<GroupOrder> GroupOrders { get; set; }

        bool HasChanges();
        int SaveChanges();
    }
}
