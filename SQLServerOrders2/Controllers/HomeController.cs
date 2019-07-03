using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SQLServerOrders2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "CRUD Contacts/Orders";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "elizabeth.a.thompson@state.mn.us";

            return View();
        }
    }
}