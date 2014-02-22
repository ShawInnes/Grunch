using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using WebSite.Migrations;

namespace WebSite.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }
    }
}
