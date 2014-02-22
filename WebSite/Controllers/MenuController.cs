using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility.Logging;
using Grunch.Data;

namespace WebSite.Controllers
{
    public class MenuController
            : DbBaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Restaurant(int id)
        {
            return View(OrderContext.Restaurants.Where(p => p.SuburbId == id).ToList());
        }

        public ActionResult MenuGrouping(int id)
        {
            return View(OrderContext.MenuGroupings.Where(p => p.RestaurantId == id).ToList());
        }

        public ActionResult MenuItem(int id)
        {
            return View(OrderContext.MenuItems.Where(p => p.MenuGroupingId == id).ToList());
        }

    }
}
