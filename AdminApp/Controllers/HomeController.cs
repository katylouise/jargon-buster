using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Parliament.JargonBuster.Core.Services;

namespace AdminApp.Controllers
{
    public class HomeController : Controller
    {
        private IDefinitionsService _definitionsService;

        public HomeController(IDefinitionsService definitionsService)
        {
            _definitionsService = definitionsService;
        }

        public ActionResult Index()
        {
            return View();
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