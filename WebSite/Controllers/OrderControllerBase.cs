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

    public class DbBaseController : Controller
    {
        public IOrderDbContext OrderContext { get; set; }
        public ILoggerFactory LoggerFactory { get; set; }

        public ILogger Logger
        {
            get { return LoggerFactory.GetCurrentInstanceLogger(); }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
//            Logger.Trace("OnActionExecuting :: {0}", this.GetType().Name);
            base.OnActionExecuting(filterContext);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //Logger.Trace("OnActionExecuted :: {0}", this.GetType().Name);
            if (filterContext.Exception == null && OrderContext != null && OrderContext.HasChanges())
            {
                //Logger.Trace("OnActionExecuted :: OrderContext.SaveChanges :: {0}", this.GetType().Name);
                OrderContext.SaveChanges();
            }

            base.OnActionExecuted(filterContext);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && OrderContext != null)
            {
                OrderContext.Dispose();
                OrderContext = null;
            }
            base.Dispose(disposing);
        }
    }
}
