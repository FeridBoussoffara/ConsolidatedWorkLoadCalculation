using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CWC.MVC.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.ClassLiDash = "nav-item start active open";
            ViewBag.ClassspanDash = "selected";
            ViewBag.ClassSpan2Dash = "arrow open";
             
            return View();
        }

        public ActionResult GotoProductIndex()
        {
            return View("Product/Index");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}