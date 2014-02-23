using Grunch.Core;
using Grunch.Data;
using Grunch.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    [Authorize]
    public class HomeController 
        : DbBaseController
    {
        private ICodeWordService CodeWordService { get; set; }

        /// <summary>
        /// Initializes a new instance of the HomeController class.
        /// </summary>
        public HomeController(ICodeWordService codeWordService)
        {
            CodeWordService = codeWordService;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            List<GroupOrder> list = OrderContext.GroupOrders.Where(p => p.Status == OrderStatus.Open).ToList();
            ViewBag.CodeWord = CodeWordService.GetCodeWord();

            return View(list);
        }

        public ActionResult Create()
        {
            GroupOrder groupOrder = new GroupOrder();
            groupOrder.Owner = HttpContext.User.Identity.Name;

            return View(groupOrder);
        }

        [HttpPost]
        public ActionResult Create(GroupOrder groupOrder)
        {
            if (ModelState.IsValid && groupOrder.Owner == HttpContext.User.Identity.Name)
            {
                OrderContext.GroupOrders.Add(groupOrder); 
                return RedirectToAction("Index");
            }
            else
            {
                return View(groupOrder);
            } 
        }

        public ActionResult PlaceOrder(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult PlaceOrder(int id, Order order)
        {
            if (ModelState.IsValid)
            {
                GroupOrder groupOrder = OrderContext.GroupOrders.Find(id);
                groupOrder.Orders.Add(order);

                return RedirectToAction("Index");
            }
            else
            {
                return View(order);
            }
        }

        [AllowAnonymous]
        public ActionResult Claims()
        {
            ViewBag.ClaimsIdentity = Thread.CurrentPrincipal.Identity;
            return View();
        }

        [AllowAnonymous]
        [Route("home/features")]
        public ActionResult Features()
        {
            return View(Feature.GetFeatures());
        }

        [AllowAnonymous]
        [Route("home/features/{feature}/{enabled}")]
        public ActionResult Features(Feature? feature, bool? enabled)
        {
            if (feature.HasValue && enabled.HasValue)
            {
                Feature.SetFeature(feature.Value, enabled.Value);
                return RedirectToAction("Features", "Home", new { });
            }

            return View(Feature.GetFeatures());
        }
    }
}