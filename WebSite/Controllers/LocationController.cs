using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility.Logging;
using Grunch.Data;

namespace WebSite.Controllers
{
    public class LocationController
            : DbBaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Country()
        {
            return View(OrderContext.Countries.ToList());
        }

        public ActionResult State(int id)
        {
            return View(OrderContext.States.Where(p => p.CountryId == id).ToList());
        }

        public ActionResult Suburb(int id)
        {
            return View(OrderContext.Suburbs.Where(p => p.StateId == id).ToList());
        }
    }
}
