using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility.Logging;
using Grunch.Data;

namespace WebSite.Controllers
{
    public class OrderControllerBase : Controller
    {
        public IOrderDbContext OrderContext { get; set; }
        public ILoggerFactory LoggerFactory { get; set; }

        public ILogger Logger
        {
            get { return LoggerFactory.GetCurrentInstanceLogger(); }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception == null && OrderContext != null && OrderContext.HasChanges())
                OrderContext.SaveChanges();

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
