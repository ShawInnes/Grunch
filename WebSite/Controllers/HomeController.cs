using Grunch.Core;
using Grunch.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    [Authorize]
    public class HomeController 
        : OrderControllerBase
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            List<GroupOrder> list = OrderContext.GroupOrders.Where(p => p.Status == OrderStatus.Open).ToList();

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
    }
}