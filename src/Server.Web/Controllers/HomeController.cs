using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Server.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [Route("graphiql")]
        public ActionResult GraphiQL()
        {
            ViewBag.Title = "GraphiQL";

            return View();
        }
    }
}
