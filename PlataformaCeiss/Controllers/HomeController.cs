using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlataformaCeiss.Controllers
{
    public class HomeController : Controller
    {
        [Route("{*pathinfo}")]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
