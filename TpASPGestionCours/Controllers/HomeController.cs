using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TpASPGestionCours.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Votre page de description d’application.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Votre page de contact.";

            return View();
        }
        public ActionResult DetailsPlus()
        {
            ViewBag.Message = "Votre page de details.";

            return View();
        }
        public ActionResult Service()
        {
            ViewBag.Message = "Votre page de Service.";

            return View();
        }
    }
}
