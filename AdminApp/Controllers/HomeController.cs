using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Parliament.JargonBuster.Core.Services;
using AdminApp.ViewModelBuilders;

namespace AdminApp.Controllers
{
    public class HomeController : Controller
    {
        private IDefinitionsViewModelBuilder _definitionsViewModelBuilder;

        public HomeController(IDefinitionsViewModelBuilder definitionsViewModelBuilder)
        {
            _definitionsViewModelBuilder = definitionsViewModelBuilder;
        }

        public ActionResult Index()
        {
            var model = _definitionsViewModelBuilder.Build();
            return View(model);
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