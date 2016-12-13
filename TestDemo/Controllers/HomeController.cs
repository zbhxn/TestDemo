using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["DataMsg"] = "TestDemoViewData";
            ViewBag.BagMsg = "TestDemoViewBag";
            return View();
        }
    }
}