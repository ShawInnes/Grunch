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
