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
    public class PersonController
            : OrderControllerBase
    {
        public ActionResult Create()
        {
            Person person = new Person();

            return View(person);
        }
    }
}
